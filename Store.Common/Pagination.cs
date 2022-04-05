using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common
{
    public static class Pagination
    {
        public static IEnumerable<TSource> ToPaged <TSource>(this IEnumerable<TSource> source ,int page , int pagesize , out int rowscount)
        {
            rowscount = source.Count();
            return source.Skip(( page - 1 ) * pagesize).Take(pagesize);
        }
    }
}
