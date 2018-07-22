using System.Collections.Generic;

namespace Systrade.Clientes.Domain.DTO
{
    public class PagedClientes<T> where T : class
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}
