using csjvm.entry;

namespace csjvm.classdefination.constantpool.impl
{
    
    /// <summary>
    /// CONSTANT_Class_info {
    ///    u1 tag;
    ///    u2 name_index;
    /// }
    /// </summary>
    public class ConstantClassInfo : ConstantPoolInfo
    {
        private ushort NameIndex { set; get; }

     
        public override ConstantPoolInfo ReadNotPublic(ClassData classData, ConstantPool constantPool)
        {
            this.NameIndex = classData.ReadUint16();
            return this;
        }
    }
}