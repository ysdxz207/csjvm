using csjvm.classdefination.common;
using csjvm.entry;

namespace csjvm.classdefination.constantpool
{
    /// <summary>
    /// 描述：常量池信息
    /// 创建者：ysdxz207
    /// 创建时间：2020年3月3日 21:41:13
    /// </summary>
    public abstract class ConstantPoolInfo : IConstantPoolReadable<ConstantPoolInfo>
    {
        private byte Tag { set; get; }

        public ConstantPoolInfo Read(ClassData classData, ConstantPool constantPool)
        {
            this.Tag = classData.ReadUint8();

            return ReadNotPublic(classData, constantPool);
        }

        public abstract ConstantPoolInfo ReadNotPublic(ClassData classData, ConstantPool constantPool);
    }
}