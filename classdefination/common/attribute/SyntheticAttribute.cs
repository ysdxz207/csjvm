using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// Synthetic_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///}
    /// </summary>
    public class SyntheticAttribute : AttributeInfo
    {
        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
        }
    }
}