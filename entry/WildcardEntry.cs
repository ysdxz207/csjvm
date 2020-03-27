using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using csjvm.classdefination;
using csjvm.exception;
/// <summary>
/// 描述：通配符类型的入口
/// 创建者：ysdxz207
/// </summary>
namespace csjvm.entry
{
    class WildcardEntry : IEntry
    {
        // 通配符类型其实也相当于多路径组合
        readonly IEntry [] _entrys;

        public WildcardEntry(string path)
        {
            if (path.EndsWith("*"))
            {
                path = path.Remove(path.Length - 1);
            }

            var entryList = new List<IEntry>();

            var directoryInfo = new DirectoryInfo(path);

            if (!directoryInfo.Exists)
            {
                return;
            }
            // 遍历目录(不包含子目录)
            var files = directoryInfo.GetFileSystemInfos();

            foreach (var fileSystemInfo in files)
            {
                if (fileSystemInfo is FileInfo fileInfo && fileInfo.Name.ToLower().EndsWith(".jar"))
                {
                    entryList.Add(new ZipEntry(fileInfo.FullName));
                }
            }
            this._entrys = entryList.ToArray();
        }

        public ClassData ReadClass(string className)
        {
            foreach (var zipEntry in _entrys)
            {
                try
                {
                    return zipEntry.ReadClass(className);
                } catch(Exception)
                {
                    continue;
                }
            }

            throw new ClassNotFoundException("Can not found class:" + className);
        }
    }
}
