using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;

namespace DotNet.Utilities
{
    public class AutoProfile : Profile
    {
        public AutoProfile()
        {
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            var types = assemblies.SelectMany(a => a.GetTypes());

            ConfigMap(types, typeof(IMapTo<>));
            ConfigMap(types, typeof(IMapFrom<>));
            ConfigMap(types, typeof(IMap<>));
        }

        /// <summary>
        /// 根据 自动映射接口类型 注册映射
        /// </summary>
        /// <param name="types"></param>
        /// <param name="mapInterfaceType">自动映射接口类型</param>
        private void ConfigMap(IEnumerable<Type> types, Type mapInterfaceType)
        {
            types.Where(t => t.GetInterfaces().Any(interfaces => interfaces.IsGenericType && interfaces.GetGenericTypeDefinition() == mapInterfaceType))
                 .ToList().ForEach(lmpType =>
                 {
                     //lmpType可以实现多个mapInterfaceType接口
                     lmpType.GetInterfaces().Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == mapInterfaceType)
                                .ToList().ForEach(mapInterface =>
                                {
                                    var genericArgumentType = mapInterface.GetGenericArguments()[0];
                                    if (mapInterfaceType == typeof(IMapTo<>) ||
                                        mapInterfaceType == typeof(IMap<>))
                                    {
                                        CreateMap(lmpType, genericArgumentType);
                                    }

                                    if (mapInterfaceType == typeof(IMapFrom<>) ||
                                        mapInterfaceType == typeof(IMap<>))
                                    {
                                        CreateMap(genericArgumentType, lmpType);
                                    }
                                });
                 });
        }
    }
}
