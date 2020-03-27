using csjvm.classdefination.constantpool.impl;
using csjvm.exception;

/// <summary>
/// 描述：常量池
/// 创建者：ysdxz207
/// 创建日期：2020年3月2日 23:14:15
/// </summary>
namespace csjvm.classdefination.constantpool
{
    public class ConstantPool
    {
        public ConstantPoolInfo[] ConstantPoolInfos { set; get; }

        public ConstantPoolInfo GetConstantInfo(ushort index)
        {
            if (index >= this.ConstantPoolInfos.Length)
            {
                throw new InvalidConstantPoolIndexError("Index out of bounds :" + index);
            }

            var constantPoolInfo = this.ConstantPoolInfos[index];
            if (constantPoolInfo == null)
            {
                throw new InvalidConstantPoolIndexError("Can not found constant pool index :" + index);
            }

            return constantPoolInfo;
        }
        
        
        
        public string GetUtf8(ushort index)
        {
            return (this.GetConstantInfo(index) as ConstantUtf8Info)?.Value;
        }
    }
}
