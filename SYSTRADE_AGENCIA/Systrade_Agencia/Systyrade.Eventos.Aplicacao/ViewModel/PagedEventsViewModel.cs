using System.Collections.Generic;

namespace Systyrade.Eventos.Aplicacao.ViewModel
{
    public class PagedEventsViewModel<T>  where T : class
    {
        public IEnumerable<T> List { get; set; }
    }
}
