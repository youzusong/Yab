using System;
using System.IO;

namespace Yab.Modularity.Plugins
{
    public static class PluginSourceListExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="moduleTypes"></param>
        public static void AddTypes(this PluginSourceList list, params Type[] moduleTypes)
        {
            Check.NotNull(list, nameof(list));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="filePaths"></param>
        public static void AddFiles(this PluginSourceList list, params string[] filePaths)
        {
            Check.NotNull(list, nameof(list));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="folder"></param>
        /// <param name="searchOption"></param>
        public static void AddFolder(this PluginSourceList list, string folder, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            Check.NotNull(list, nameof(list));

        }
    }
}
