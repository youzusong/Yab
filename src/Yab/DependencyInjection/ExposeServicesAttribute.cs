using System;
using System.Collections.Generic;
using System.Linq;

namespace Yab.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public class ExposeServicesAttribute : Attribute
    {
        public Type[] ServiceTypes { get; }

        public bool IncludeDefaults { get; set; }

        public bool IncludeSelf { get; set; }

        public ExposeServicesAttribute(params Type[] serviceTypes)
        {
            ServiceTypes = serviceTypes ?? new Type[0];
        }

        public Type[] GetExposedServiceTypes(Type targetType)
        {
            var serviceTypeList = ServiceTypes.ToList();

            if (IncludeDefaults)
            {
                foreach (var type in DependencyUtility.GetDefaultServices(targetType))
                {
                    serviceTypeList.AddIfNotContains(type);
                }

                if (IncludeSelf)
                    serviceTypeList.AddIfNotContains(targetType);
            }
            else if (IncludeSelf)
            {
                serviceTypeList.AddIfNotContains(targetType);
            }

            return serviceTypeList.ToArray();
        }
    }
}
