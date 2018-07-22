using AutoMapper;
using Systrade.Events.Dominio.DTO;
using Systrade.Eventos.Aplicacao.ViewModel;
using Systrade.Events.Dominio.Entidades;
using Systyrade.Eventos.Aplicacao.ViewModel;

namespace Systyrade.Eventos.Aplicacao.AutoMapper
{
    public class EventsDomainToViewModelMappingProfile : Profile
    {
        public EventsDomainToViewModelMappingProfile()
        {
            CreateMap<PagedEvent<UsuarioEvents>, PagedEventsViewModel<UsuarioEventsViewModel>>();
        }
    }
}
