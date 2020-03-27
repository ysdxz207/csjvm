using System;

namespace csjvm.classdefination.constantpool.impl
{
    /// <summary>
    /// CONSTANT_Integer_info {
    ///    u1 tag;
    ///    u4 bytes;
    /// }
    /// </summary>
    public class ConstantIntegerInfo : ConstantPoolInfo
    {
        
        private uint Value { set; get; }
        

        public override ConstantPoolInfo ReadNotPublic(ClassData classData, ConstantPool constantPool)
        {
            this.Value = classData.ReadUint32();
            return this;
        }
    }
}