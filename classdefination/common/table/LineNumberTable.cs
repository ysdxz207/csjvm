namespace csjvm.classdefination.common.table
{
    /// <summary>
    /// LineNumberTable_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u2 line_number_table_length;
    ///    {   u2 start_pc;
    ///        u2 line_number;	
    ///    } line_number_table[line_number_table_length];
    ///}
    /// </summary>
    public class LineNumberTable : IReadable<LineNumberTable>
    {
        public ushort StartPc { set; get; }
        public ushort LineNumber { set; get; }

        public LineNumberTable Read(ClassData classData)
        {
            this.StartPc = classData.ReadUint16();
            this.LineNumber = classData.ReadUint16();

            return this;
        }
    }
}