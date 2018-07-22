using System.Collections.Generic;

namespace Systrade.Events.Dominio.DTO
{
    public class PagedEvent<T> where T : class
    {
        public IEnumerable<T> List { get; set; }
    }
}
