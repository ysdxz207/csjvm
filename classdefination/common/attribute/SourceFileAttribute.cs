using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// SourceFile_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u2 sourcefile_index;
    ///}

    /// </summary>
    public class SourceFileAttribute : AttributeInfo
    {
        private ushort SourcefileIndex { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.SourcefileIndex = classData.ReadUint16();
        }
    }
}