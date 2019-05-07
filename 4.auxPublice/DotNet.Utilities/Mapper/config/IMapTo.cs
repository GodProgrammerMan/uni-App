using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Utilities
{
    /// <summary>
    /// 映射到<typeparam name="TDestination">TDestination</typeparam>类型
    /// </summary>
    /// <typeparam name="TDestination"></typeparam>
    public interface IMapTo<TDestination>
        where TDestination : class, new()
    {
    }
}
