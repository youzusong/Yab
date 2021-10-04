using System;
using System.Collections.Generic;
using System.Reflection;

namespace Yab.DependencyInjection
{
    public static class DependencyUtility
    {
        /// <summary>
        /// 获取默认服务
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<Type> GetDefaultServices(Type type)
        {
            var serviceTypes = new List<Type>();

            foreach (var interfaceType in type.GetTypeInfo().GetInterfaces())
            {
                var interfaceName = interfaceType.Name;

                if (interfaceName.StartsWith("I"))
                {
                    interfaceName = interfaceName.Substring(1);
                }

                if (type.Name.EndsWith(interfaceName))
                {
                    serviceTypes.Add(interfaceType);
                }
            }

            return serviceTypes;
        }
    }
}
