using System;
using System.Collections.Generic;
using System.Reflection;

namespace Yab.Reflection
{
    /// <summary>
    /// 类型探测器接口
    /// </summary>
    public interface ITypeFinder
    {
        /// <summary>
        /// 获取有所程序集
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<Assembly> GetAssemblies();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="onlyConcreteClasses"></param>
        /// <returns></returns>
        IReadOnlyList<Type> GetClassesOfType<T>(bool onlyConcreteClasses = true);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assignTypeFrom"></param>
        /// <param name="onlyConcreteClasses"></param>
        /// <returns></returns>
        IReadOnlyList<Type> GetClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblies"></param>
        /// <param name="onlyConcreteClasses"></param>
        /// <returns></returns>
        IReadOnlyList<Type> GetClassesOfType<T>(IReadOnlyList<Assembly> assemblies, bool onlyConcreteClasses = true);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assignTypeFrom"></param>
        /// <param name="assemblies"></param>
        /// <param name="onlyConcreteClasses"></param>
        /// <returns></returns>
        IReadOnlyList<Type> GetClassesOfType<T>(Type assignTypeFrom, IReadOnlyList<Assembly> assemblies, bool onlyConcreteClasses = true);
    }
}
