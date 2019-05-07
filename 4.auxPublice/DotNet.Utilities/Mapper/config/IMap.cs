using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace DotNet.Utilities
{
    /// <summary>
    /// 与<typeparam name="TEntity">TEntity</typeparam>类型双向映射
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IMap<TEntity>
        where TEntity : class, new()
    {
    }
}
