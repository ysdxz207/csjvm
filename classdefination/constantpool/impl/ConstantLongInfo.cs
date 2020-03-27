﻿namespace csjvm.classdefination.constantpool.impl
{
    /// <summary>
    /// CONSTANT_Long_info {
    ///    u1 tag;
    ///    u4 high_bytes;
    ///    u4 low_bytes;
    /// }
    /// </summary>
    public class ConstantLongInfo : ConstantPoolInfo
    {
        private uint HighBytes { set; get; }
        private uint LowBytes { set; get; }
        

        public override ConstantPoolInfo ReadNotPublic(ClassData classData, ConstantPool constantPool)
        {
            this.HighBytes = classData.ReadUint32();
            this.LowBytes = classData.ReadUint32();
            return this;
        }
    }
}