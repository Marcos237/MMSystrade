using System;
using System.Collections.Generic;
using Systrade.Clientes.Applications.ViewModel;
using Systrade.Clientes.Domain.Entidades;

namespace Systrade.Clientes.Applications.Interfaces
{
    public interface IClienteAppService
    {
        bool AdicionarCelula(CelulaViewModel celula);
        bool AtualizarCelula(CelulaViewModel celula);
        bool DeletarCelula(CelulaViewModel celula);
        bool RestaurarCelula(CelulaViewModel model);
        List<Celula> BuscarCelulasPorAgenciaid(Guid agenciaid);
        CelulaViewModel ObeterCelulaPorId(Guid id);

        PagedClienteViewModel<CelulaViewModel> ObterTodosCelulasInativos(Guid id, string descricao, int pageSize, int pageNumber);

    }
}
