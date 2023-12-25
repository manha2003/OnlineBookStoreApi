using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers
{
    public static class Paging
    {
        public static IEnumerable<T> GetPage<T>(IEnumerable<T> items, int pageNumber, int pageSize)
        {
            return items.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
