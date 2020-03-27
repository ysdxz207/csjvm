namespace csjvm.classdefination.constantpool.impl
{
    /// <summary>
    /// CONSTANT_NameAndType_info {
    ///    u1 tag;
    ///    u2 name_index;
    ///    u2 descriptor_index;
    /// }
    /// </summary>
    public class ConstantNameAndTypeInfo : ConstantPoolInfo
    {
        
        private ushort NameIndex { set; get; }
        
        private ushort DescriptorIndex { set; get; }

        public override ConstantPoolInfo ReadNotPublic(ClassData classData, ConstantPool constantPool)
        {
            this.NameIndex = classData.ReadUint16();
            this.DescriptorIndex = classData.ReadUint16();

            return this;
        }
    }
}