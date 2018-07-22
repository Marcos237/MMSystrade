using AutoMapper;
using System;
using System.Collections.Generic;
using Systrade.Clientes.Applications.Adapters;
using Systrade.Clientes.Applications.Interfaces;
using Systrade.Clientes.Applications.ViewModel;
using Systrade.Clientes.Domain.Entidades;
using Systrade.Clientes.Domain.Intefaces.Services;
using Systrade.Clientes.Infra.Data.Interfaces;

namespace Systrade.Clientes.Applications.Services
{
    public class ClienteAppService : ApplicationService, IClienteAppService
    {
        private readonly IClienteService _celulaservice;

        public ClienteAppService(IClienteService celulaservice, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _celulaservice = celulaservice;
        }

        public bool AdicionarCelula(CelulaViewModel celula)
        {
            var status = false;
            var _celula = AdicionarCelulaAdapter.ToDomainModel(celula);
            SalvarCelula(_celula);

            if (Commit())
                status = true;

            return status;
        }


        public Celula SalvarCelula(Celula celula)
        {
            if (!Notifications.HasNotifications())
            {
                _celulaservice.AdicionarCelula(celula);
            }

            return celula;
        }

        public bool AtualizarCelula(CelulaViewModel model)
        {
            var status = false;
            var _celula = AdicionarCelulaAdapter.ToDomainModel(model);
            EditarCelula(_celula);
            if (Commit())
                status = true;

            return status;
        }

        public Celula EditarCelula(Celula celula)
        {
            if (!Notifications.HasNotifications())
            {
                _celulaservice.AtualizarCelula(celula);
            }

            return celula;
        }

        public List<Celula> BuscarCelulasPorAgenciaid(Guid agenciaid)
        {
            var result = _celulaservice.BuscarCelulaPorAgenciaId(agenciaid);
            return result;
        }

        public bool DeletarCelula(CelulaViewModel celula)
        {
            var status = false;
            var _celula = AdicionarCelulaAdapter.ToDomainModel(celula);
            ExcluirCelula(_celula);
            if (Commit())
                status = true;

            return status;
        }

        public Celula ExcluirCelula(Celula celula)
        {
            if (!Notifications.HasNotifications())
            {
                _celulaservice.ExcluirCelula(celula);
            }

            return celula;
        }

        public CelulaViewModel ObeterCelulaPorId(Guid id)
        {
            return Mapper.Map<CelulaViewModel>(_celulaservice.ObterCelulaPorId(id));
        }

        public PagedClienteViewModel<CelulaViewModel> ObterTodosCelulasInativos(Guid id, string descricao, int pageSize, int pageNumber)
        {
            return Mapper.Map<PagedClienteViewModel<CelulaViewModel>>(_celulaservice.ObterTodosCelulaInativos(id, descricao, pageSize, pageNumber));
        }

        public bool RestaurarCelula(CelulaViewModel model)
        {
            var status = false;
            var _celula = AdicionarCelulaAdapter.ToDomainModel(model);
            AtivarCelula(_celula);
            if (Commit())
                status = true;

            return status;
        }

        public Celula AtivarCelula(Celula celula)
        {
            if (!Notifications.HasNotifications())
            {
                _celulaservice.RestaurarCelula(celula);
            }

            return celula;
        }
    }
}
