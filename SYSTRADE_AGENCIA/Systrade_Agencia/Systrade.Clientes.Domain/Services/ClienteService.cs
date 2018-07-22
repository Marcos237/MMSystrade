using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using Systrade.Clientes.Domain.DTO;
using Systrade.Clientes.Domain.Entidades;
using Systrade.Clientes.Domain.Entidades.Celulas.Validation;
using Systrade.Clientes.Domain.Entidades.Validation;
using Systrade.Clientes.Domain.Intefaces.Repository;
using Systrade.Core.Events;

namespace Systrade.Clientes.Domain.Intefaces.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ICelulaRepository _celularepository;
        public ClienteService(ICelulaRepository celularepository)
        {
            _celularepository = celularepository;
        }

        private static bool PossuiConformidade(ValidationResult validationResult)
        {
            if (validationResult == null) return true;
            var notifications = validationResult.Erros.Select(validationError => new DomainNotification(validationError.ToString(), validationError.Message)).ToList();
            if (!notifications.Any()) return true;
            notifications.ToList().ForEach(DomainEvent.Raise);
            return false;
        }


        public Celula AdicionarCelula(Celula celula)
        {
            if (PossuiConformidade(new CelulaEstaConsistenteValidation(_celularepository).Validate(celula)))
                _celularepository.AdicionarCelula(celula);

            return celula;
        }

        public Celula AtualizarCelula(Celula celula)
        {
            if (PossuiConformidade(new CelulaEstaConsitenteParaEditarSpecification().Validate(celula)))
                _celularepository.Atualizar(celula);

            return celula;
        }

        public List<Celula> BuscarCelulaPorAgenciaId(Guid id)
        {
            return _celularepository.BuscarCelulaPorAgenciaId(id);
        }

        public Celula BuscarNomeCelula(string nomecelula)
        {
            return _celularepository.BuscarNomeCelula(nomecelula);
        }

        public Celula ExcluirCelula(Celula celula)
        {
            celula.DesativarCelula();
            return _celularepository.AtualizarCelula(celula);
        }

        public Celula ObterCelulaPorId(Guid id)
        {
            return _celularepository.ObterCelulaPorId(id);
        }

        public PagedClientes<Celula> ObterTodosCelulaInativos(Guid id, string descricao, int pageSize, int pageNumber)
        {
            return _celularepository.ObterTodosCelulaInativos(id, descricao, pageSize, pageNumber);
        }

        public Celula RestaurarCelula(Celula celula)
        {
            celula.AtivarCelula();
            return _celularepository.AtualizarCelula(celula);
        }
    }
}
