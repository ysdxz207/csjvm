namespace csjvm.classdefination.constantpool.impl
{
    /// <summary>
    /// CONSTANT_Fieldref_info {
    ///    u1 tag;
    ///    u2 class_index;
    ///    u2 name_and_type_index;
    /// }
    /// </summary>
    public class ConstantFieldRefInfo : ConstantPoolInfo
    {
        
        private ushort ClassIndex { set; get; }
        
        private ushort NameAndTypeIndex { set; get; }
        


        public override ConstantPoolInfo ReadNotPublic(ClassData classData, ConstantPool constantPool)
        {
            this.ClassIndex = classData.ReadUint16();
            this.NameAndTypeIndex = classData.ReadUint16();
            return this;
        }
    }
}