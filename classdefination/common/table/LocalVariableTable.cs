using System.Xml.Linq;

namespace csjvm.classdefination.common.table
{
    /// <summary>
    /// LocalVariableTable_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u2 local_variable_table_length;
    ///    {   u2 start_pc;
    ///        u2 length;
    ///        u2 name_index;
    ///        u2 descriptor_index;
    ///        u2 index;
    ///    } local_variable_table[local_variable_table_length];
    ///}
    /// </summary>
    public class LocalVariableTable : LineNumberTable
    {
        public ushort NameIndex { set; get; }
        public ushort DescriptorIndex { set; get; }
        public ushort Index { set; get; }

        public LocalVariableTable Read(ClassData classData)
        {
            base.Read(classData);

            this.NameIndex = classData.ReadUint16();
            this.DescriptorIndex = classData.ReadUint16();
            this.Index = classData.ReadUint16();

            return this;
        }
    }
}