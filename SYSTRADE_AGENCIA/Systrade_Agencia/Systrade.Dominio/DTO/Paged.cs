using System.Collections.Generic;

namespace Systrade.Dominio.DTO
{
    public class Paged<T> where T : class
    {
        public IEnumerable<T> List { get; set; }
        public int Count { get; set; }
    }
}
