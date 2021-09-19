using System;
using System.Linq;

namespace Yab.Background
{
    /// <summary>
    /// 后台任务工具类
    /// </summary>
    public static class BackgroundJobUtility
    {
        /// <summary>
        /// 获取任务名称
        /// </summary>
        /// <param name="argsType"></param>
        /// <returns></returns>
        public static string GetJobName(Type argsType)
        {
            Check.NotNull(argsType, nameof(argsType));

            return argsType
                       .GetCustomAttributes(true)
                       .OfType<IBackgroundJobNameProvider>()
                       .FirstOrDefault()
                       ?.Name
                   ?? argsType.FullName;
        }

        /// <summary>
        /// 获取任务名称
        /// </summary>
        /// <typeparam name="TArgs"></typeparam>
        /// <returns></returns>
        public static string GetJobName<TArgs>()
        {
            return GetJobName(typeof(TArgs));
        }

        /// <summary>
        /// 获取参数类型
        /// </summary>
        /// <param name="jobType"></param>
        /// <returns></returns>
        public static Type GetArgsType(Type jobType)
        {
            foreach (var item in jobType.GetInterfaces())
            {
                if (!item.IsGenericType)
                {
                    continue;
                }

                if (item.GetGenericTypeDefinition() != typeof(IBackgroundJob<>) &&
                    item.GetGenericTypeDefinition() != typeof(IAsyncBackgroundJob<>))
                {
                    continue;
                }

                var genericArgs = item.GetGenericArguments();
                if (genericArgs.Length != 1)
                {
                    continue;
                }

                return genericArgs[0];
            }

            throw new YabException($"未能找到后台任务参数类型：{jobType.AssemblyQualifiedName}");
        }
    }
}
