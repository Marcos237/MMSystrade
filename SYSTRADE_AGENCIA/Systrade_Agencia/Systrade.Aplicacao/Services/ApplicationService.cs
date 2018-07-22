using Systrade.Core.Events;
using Systrade.Core.Interfaces;
using Systrade.Dominio.Interfaces.Uow;

namespace Systrade.Aplicacao.Services.UoW
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IHandler<DomainNotification> Notifications;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this.Notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
        }
        public bool Commit()
        {
            if (Notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }
    }
}
