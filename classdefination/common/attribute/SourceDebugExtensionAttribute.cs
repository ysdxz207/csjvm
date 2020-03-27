using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// SourceDebugExtension_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u1 debug_extension[attribute_length];
    ///}
    /// </summary>
    public class SourceDebugExtensionAttribute : AttributeInfo
    {
        private byte DebugExtension { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.DebugExtension = classData.ReadUint8();
        }
    }
}