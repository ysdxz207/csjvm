namespace csjvm.classdefination.constantpool.impl
{
    
    /// <summary>
    /// CONSTANT_String_info {
    ///    u1 tag;
    ///    u2 string_index;
    /// }
    /// </summary>
    public class ConstantStringInfo : ConstantPoolInfo
    {
        private ushort StringIndex { set; get; }



        public override ConstantPoolInfo ReadNotPublic(ClassData classData, ConstantPool constantPool)
        {
            this.StringIndex = classData.ReadUint16();
            return this;
        }
    }
}