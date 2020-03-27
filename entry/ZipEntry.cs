using System.IO;
using System.IO.Compression;
using csjvm.classdefination;
using csjvm.exception;

/// <summary>
/// 描述：zip包类型的入口
/// 创建者：ysdxz207
/// </summary>
namespace csjvm.entry
{
    class ZipEntry : IEntry
    {
        readonly string AbsolutePath;

        public ZipEntry(string path)
        {
            this.AbsolutePath = Path.GetFullPath(path);
        }

        public ClassData ReadClass(string className)
        {
            var zip = ZipFile.OpenRead(AbsolutePath);

            var byteArr = FindFileFromZip(className, zip);

            zip.Dispose();
            
            return new ClassData(byteArr);
        }

        private byte [] FindFileFromZip(string className, ZipArchive zip)
        {
            foreach (ZipArchiveEntry zipEntry in zip.Entries)
            {
                // 文件类型
                var isFile = !zipEntry.FullName.EndsWith("/");
                if (!isFile) continue;
                if (zipEntry.FullName.Equals(className))
                {
                    byte[] bytes;
                    using (var ms = new MemoryStream())
                    {
                        zipEntry.Open().CopyTo(ms);
                        bytes = ms.ToArray();
                    }
                    return bytes;
                } else
                {
                    continue;
                }
            }
            throw new ClassNotFoundException("Can not found class:" + className);
        }
    }
}
