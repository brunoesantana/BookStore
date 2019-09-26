using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.CrossCutting.Helper
{
    public static class MapperHelper
    {
        public static IEnumerable<TDestiny> CopyList<TOrigin, TDestiny>(IEnumerable<TOrigin> src)
        {
            var ret = new List<TDestiny>();
            if (src == null)
            {
                return ret;
            }

            //FIXME
            ret.AddRange(src.Select(origin => (TDestiny)AutoMapper.Mapper.Map(origin, typeof(TOrigin), typeof(TDestiny))));
            return ret;
        }

        public static TDestiny Map<TSource, TDestiny>(TSource origin)
        {
            //FIXME
            return AutoMapper.Mapper.Map<TDestiny>(origin);
        }
    }
}
