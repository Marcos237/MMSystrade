using AutoMapper;
using Systrade.Aplicacao.ViewModel;
using Systrade.Cadastro.Identity.Model;
using Systrade.Dominio.DTO;
using Systrade.Dominio.Enderecos.Entidades;
using Systrade.Dominio.Entidade;
using Systrade.Dominio.Entidade.Usuarios;
using Systrade.Dominio.Entidades;

namespace Systrade.Aplicacao.AutoMaper
{
    class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Agencia, AgenciaViewModel>()
                .ForMember(d => d.CNPJ, opt => opt.MapFrom(src => src.CNPJ.Codigo));

            CreateMap<Agencia, RegisterViewModel>();

            CreateMap<Endereco, EnderecoViewModel>()
            .ForMember(d => d.Cep, opt => opt.MapFrom(src => src.Cep.CepCod));

            CreateMap<EnderecoDto, EnderecoViewModel>();

            CreateMap<Paged<EnderecoDto>, PagedViewModel<EnderecoViewModel>>();

            CreateMap<AgenciaUsuario, AgenciaUsuarioViewModel>()
            .ForMember(d => d.CPF, opt => opt.MapFrom(src => src.CPF.Codigo))
            .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email.Endereco))
            .ForMember(d => d.Celular, opt => opt.MapFrom(src => src.Telefone.Celular))
            .ForMember(d => d.TelefoneFixo, opt => opt.MapFrom(src => src.Telefone.Fixo));

            CreateMap<AgenciaUsuario, EditarAgenciaUsuarioViewModel>()
            .ForMember(d => d.CPF, opt => opt.MapFrom(src => src.CPF.Codigo))
            .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email.Endereco))
            .ForMember(d => d.Celular, opt => opt.MapFrom(src => src.Telefone.Celular))
            .ForMember(d => d.TelefoneFixo, opt => opt.MapFrom(src => src.Telefone.Fixo));

            CreateMap<Paged<AgenciaUsuario>, PagedViewModel<AgenciaUsuarioViewModel>>();

            CreateMap<AgenciaUsuario, UsuarioViewModel>()
            .ForMember(d => d.CPF, opt => opt.MapFrom(src => src.CPF.Codigo))
            .ForMember(d => d.Email, opt => opt.MapFrom(src => src.Email.Endereco))
            .ForMember(d => d.Celular, opt => opt.MapFrom(src => src.Telefone.Celular))
            .ForMember(d => d.TelefoneFixo, opt => opt.MapFrom(src => src.Telefone.Fixo));

            CreateMap<RegistroUsuario, UserViewModel>();
            CreateMap<Paged<RegistroUsuario>, PagedViewModel<UserViewModel>>();

        }
    }
}
