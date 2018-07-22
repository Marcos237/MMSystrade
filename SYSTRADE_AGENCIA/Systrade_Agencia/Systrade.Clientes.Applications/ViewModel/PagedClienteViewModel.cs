using System.Collections.Generic;

namespace Systrade.Clientes.Applications.ViewModel
{
    public class PagedClienteViewModel<T> where T : class
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}