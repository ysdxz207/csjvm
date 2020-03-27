using System;

namespace csjvm.classdefination.constantpool.impl
{
    /// <summary>
    /// CONSTANT_Float_info {
    ///    u1 tag;
    ///    u4 bytes;
    /// }
    /// </summary>
    public class ConstantFloatInfo : ConstantPoolInfo
    {
        private uint Bytes { set; get; }
        
        public override ConstantPoolInfo ReadNotPublic(ClassData classData, ConstantPool constantPool)
        {
            this.Bytes = classData.ReadUint32();
            return this;
        }
    }
}