using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// attribute_info {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u1 info [attribute_length];
    /// }
    /// </summary>
    public class AttributeInfo : AbstractAttribute
    {
        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            
        }
    }
}