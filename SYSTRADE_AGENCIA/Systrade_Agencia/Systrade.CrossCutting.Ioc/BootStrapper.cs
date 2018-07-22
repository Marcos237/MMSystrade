using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using Systrade.Aplicacao.Interface;
using Systrade.Aplicacao.Services;
using Systrade.Cadastro.Identity.Context;
using Systrade.Cadastro.Identity.Model;
using Systrade.Cadastro.Identity.Model.Configuration;
using Systrade.Cadstro.Infra.CrossCutting.Loggin;
using Systrade.Core.Events;
using Systrade.Core.Handlers;
using Systrade.Core.Interfaces;
using Systrade.Dominio.Entidades.AgenciaUsuario.Events;
using Systrade.Dominio.Entidades.AgenciaUsuario.Handlers;
using Systrade.Dominio.Interfaces.Repository;
using Systrade.Dominio.Interfaces.Servicos;
using Systrade.Dominio.Interfaces.Uow;
using Systrade.Dominio.Servicos;
using Systrade.Eventos.Infra.Data.Repository;
using Systrade.Events.Dominio.Repository;
using Systrade.Infra.Data.Context;
using Systrade.Infra.Data.Helpers;
using Systrade.Infra.Data.Repository;
using Systrade.Infra.Data.UoW;
using Systyrade.Eventos.Aplicacao.Repository;
using Systyrade.Eventos.Aplicacao.Servicos;

namespace Systrade.CrossCutting.Ioc
{
    public class BootStrapper
    {
        public static Container MyContainer { get; set; }

        public static void Register(Container container)
        {
            MyContainer = container;

            //APP
            container.Register<IAgenciaAppService, AgenciaAppservice>();

            //Dominio
            container.Register<IAgenciaService, AgenciaService>(Lifestyle.Scoped);
            container.Register<IRegistroUsuarioService, RegistroUsuarioService>(Lifestyle.Scoped);


            //Infra Dados
            container.Register<IAgenciaRepository, AgenciaRepository>(Lifestyle.Scoped);
            container.Register<IAgenciaUsuarioRepository, AgenciaUsuarioRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<IClaimsRepository, ClaimRepository>(Lifestyle.Scoped);
            container.Register<IRegistroUsuarioRepository, RegistroUsuarioRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<SystradeCadastroContext>(Lifestyle.Scoped);

            // Identity
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

            // Handlers
            container.Register<IHandler<DomainNotification>, DomainNotificationHandler>(Lifestyle.Scoped);
            container.Register<IHandler<AgenciaUsuarioEvent>, AgenciaUsuarioHandler>(Lifestyle.Scoped);

            // Log
            container.Register<ILogAuditoria, LogAuditoriaHelper>(Lifestyle.Scoped);


            // Eventos App
            container.Register<IUsuarioEventsAppService, UsuarioEventsAppService>();
            container.Register<IRegistroAppService, RegistroAppService>();

            // Eventos Dados
            container.Register<IUsuarioEventRepository, UsuarioEventRepository>(Lifestyle.Scoped);
        }
    }
}
