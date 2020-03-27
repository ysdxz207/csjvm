using csjvm.entry;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 描述：简单工厂模式获取访问入口
/// 创建者：ysdxz207
/// </summary>
namespace csjvm.factory
{
    class EntryFactory
    {
        /// <summary>
        /// 默认函数，用来创建一个访问入口
        /// </summary>
        /// <param name="path">class文件路径</param>
        /// <returns></returns>
        public static IEntry GetEntry(string path)
        {
            if (path.Contains(";"))
            {
                return new CompositeEntry(path);
            }

            if (path.EndsWith("*"))
            {
                return new WildcardEntry(path);
            }

            if (path.EndsWith(".jar") || path.EndsWith(".JAR")
                || path.EndsWith(".zip") || path.EndsWith(".ZIP"))
            {
                return new ZipEntry(path);
            }
            return new DirectoryEntry(path);
        }
    }
}
