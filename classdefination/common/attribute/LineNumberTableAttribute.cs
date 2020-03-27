using csjvm.classdefination.common.table;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
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
    public class LineNumberTableAttribute : AttributeInfo
    {
        private ushort LineNumberTableLength { set; get; }
        private LineNumberTable [] LineNumberTable { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.LineNumberTableLength = classData.ReadUint16();

            this.LineNumberTable = new LineNumberTable[this.LineNumberTableLength];
            for (var i = 0; i < this.LineNumberTableLength; i++)
            {
                this.LineNumberTable[i] = new LineNumberTable().Read(classData);
            }
        }
    }
}