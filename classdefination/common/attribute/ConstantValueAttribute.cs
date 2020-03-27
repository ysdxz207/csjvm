using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// ConstantValue_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u2 constantvalue_index;
    /// }
    /// </summary>
    public class ConstantValueAttribute : AttributeInfo
    {
        /// <summary>
        /// The value of the constantvalue_index item must be a valid index into the constant_pool table.
        /// </summary>
        private ushort ConstantValueIndex { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.ConstantValueIndex = classData.ReadUint16();
        }
    }
}