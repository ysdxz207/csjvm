using System.IO;
using csjvm.classdefination;
using csjvm.exception;

/// <summary>
/// 描述：目录类型的入口
/// 创建者：ysdxz207
/// </summary>
namespace csjvm.entry
{

    class DirectoryEntry :IEntry
    {
        readonly string _absolutePath;


        public DirectoryEntry(string path)
        {
            this._absolutePath = Path.GetFullPath(path);
        }

        public ClassData ReadClass(string className)
        {
            var fullFileName = Path.Combine(_absolutePath, className);
            if (!File.Exists(fullFileName))
            {
                throw new ClassNotFoundException("Can not found class:" + className);
            }

            return new ClassData(File.ReadAllBytes(fullFileName));
        }
    }
}
