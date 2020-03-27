using csjvm.classdefination.common.frame;
using csjvm.classdefination.common.reader;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// StackMapTable_attribute {
    ///    u2              attribute_name_index;
    ///    u4              attribute_length;
    ///    u2              number_of_entries;
    ///    stack_map_frame entries[number_of_entries];
    /// }
    /// </summary>
    public class StackMapTableAttribute : AttributeInfo
    {
        private ushort NumberOfEntries { set; get; }

        private StackMapFrame [] Entries { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.NumberOfEntries = classData.ReadUint16();
            this.Entries = new StackMapFrameReader(classData).ReadStackMapFrames(this.NumberOfEntries);
        }
    }
}