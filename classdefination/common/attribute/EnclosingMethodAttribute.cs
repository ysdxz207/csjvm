using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// EnclosingMethod_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u2 class_index;
    ///    u2 method_index;
    ///}
    /// </summary>
    public class EnclosingMethodAttribute : AttributeInfo
    {
        private ushort ClassIndex { set; get; }
        private ushort MethodIndex { set; get; }


        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.ClassIndex = classData.ReadUint16();
            this.MethodIndex = classData.ReadUint16();
        }
    }
}