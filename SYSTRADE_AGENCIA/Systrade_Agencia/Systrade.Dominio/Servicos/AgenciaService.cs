using DomainValidation.Validation;
using System;
using System.Linq;
using Systrade.Core.Events;
using Systrade.Dominio.DTO;
using Systrade.Dominio.Enderecos.Entidades;
using Systrade.Dominio.Entidade;
using Systrade.Dominio.Entidades;
using Systrade.Dominio.Entidades.Enderecos.Validations;
using Systrade.Dominio.Entidades.Validations;
using Systrade.Dominio.Interfaces.Repository;
using Systrade.Dominio.Interfaces.Servicos;

namespace Systrade.Dominio.Servicos
{
    public partial class AgenciaService : IAgenciaService
    {
        private readonly IEnderecoRepository _enderecorepository;
        private readonly IAgenciaRepository _agenciarepository;
        private readonly IAgenciaUsuarioRepository _agenciausuariorepository;
        private readonly IClaimsRepository _claimrepository;


        public AgenciaService(IEnderecoRepository enderecorepository, IAgenciaRepository agenciarepository, IAgenciaUsuarioRepository agenciausuariorepository, 
            IClaimsRepository claimsRepository)
        {
            _enderecorepository = enderecorepository;
            _agenciarepository = agenciarepository;
            _agenciausuariorepository = agenciausuariorepository;
            _claimrepository = claimsRepository;
        }

        private static bool PossuiConformidade(ValidationResult validationResult)
        {
            if (validationResult == null) return true;
            var notifications = validationResult.Erros.Select(validationError => new DomainNotification(validationError.ToString(), validationError.Message)).ToList();
            if (!notifications.Any()) return true;
            notifications.ToList().ForEach(DomainEvent.Raise);
            return false;
        }

        public Agencia AdicionarAgencia(Agencia agencia)
        {
            if (PossuiConformidade(new AgenciaConsistenteParaCadastroValidation(_agenciarepository).Validate(agencia)))
                _agenciarepository.AdicionarAgencia(agencia);

            return agencia;
        }

        public Agencia AtualizarAgencia(Agencia agencia)
        {
            if (PossuiConformidade(new AgenciaConsistenteParaEdicaoValidation().Validate(agencia)))
                _agenciarepository.AtualizarAgencia(agencia);

            return agencia;
        }

        public Endereco AtualizarEndereco(Endereco endereco)
        {
            if (PossuiConformidade(new EnderecoConsistenteParaCadastroValidation().Validate(endereco)))
                _enderecorepository.AtualizarEndereco(endereco);

            return endereco;
        }


        public Endereco AdicionarEndereco(Endereco endereco)
        {
            if (PossuiConformidade(new EnderecoConsistenteParaCadastroValidation().Validate(endereco)))
                _enderecorepository.AdicionarEndereco(endereco);

            return endereco;
        }

        public Agencia BuscarPorId(Guid id)
        {
            var result = _agenciarepository.BuscarAgenciaPorId(id);
            return result;
        }

        public Endereco BuscarEnderecoPorId(Guid id)
        {
            return _enderecorepository.BuscarEnderecoPorId(id);
        }

        public Paged<EnderecoDto> ObterTodosEnderecos(Guid Id, string descricao, int pageSize, int pageNumber)
        {
            return _enderecorepository.ObterTodosEnderecos(Id, descricao, pageSize, pageNumber);
        }

        public void DeletarEndereco(Guid id)
        {
            _enderecorepository.Remover(id);
        }

        public void Dispose()
        {
            _agenciarepository.Dispose();
            _enderecorepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Agencia BuscarAgenciaCnpj(string cnpj)
        {
            return _agenciarepository.BuscarAgenciaCnpj(cnpj);
        }
    }
}
