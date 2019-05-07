using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Utilities
{
    /// <summary>
    /// 从<typeparam name="TSource">TSource</typeparam>类型映射
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    public interface IMapFrom<TSource>
        where TSource : class, new()
    {
    }
}
