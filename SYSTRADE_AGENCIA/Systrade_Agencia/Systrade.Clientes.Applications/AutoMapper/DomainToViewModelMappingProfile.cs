using AutoMapper;
using Systrade.Clientes.Applications.ViewModel;
using Systrade.Clientes.Domain.DTO;
using Systrade.Clientes.Domain.Entidades;

namespace Systrade.Clientes.Applications.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Celula, CelulaViewModel>();
            CreateMap<PagedClientes<Celula>, PagedClienteViewModel<CelulaViewModel>>();
        }
    }
}
