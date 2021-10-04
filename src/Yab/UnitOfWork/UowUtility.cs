using System.Linq;
using System.Reflection;

namespace Yab.UnitOfWork
{
    public static class UowUtility
    {

        /// <summary>
        /// 是否为Uow方法
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="uowAttribute"></param>
        /// <returns></returns>
        public static bool IsUowMethod(MethodInfo methodInfo, out UowAttribute uowAttribute)
        {
            Check.NotNull(methodInfo, nameof(methodInfo));

            // 判断方法是否有Uow特性
            var attrs = methodInfo.GetCustomAttributes<UowAttribute>(true);
            if (attrs.Any())
            {
                uowAttribute = attrs.First();
                return !uowAttribute.IsDisabled;
            }

            if (methodInfo.DeclaringType != null)
            {
                // 判断方法所在类是否有Uow特性
                attrs = methodInfo.DeclaringType.GetTypeInfo().GetCustomAttributes<UowAttribute>();
                if (attrs.Any())
                {
                    uowAttribute = attrs.First();
                    return !uowAttribute.IsDisabled;
                }

                // 判断方法所在类是否继承IUowEnabled接口
                if (typeof(IUowEnabled).IsAssignableFrom(methodInfo.DeclaringType))
                {
                    uowAttribute = null;
                    return true;
                }
            }

            uowAttribute = null;
            return false;
        }
    }
}
