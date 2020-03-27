using csjvm.classdefination.common.table;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
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
    public class LocalVariableTableAttribute : AttributeInfo
    {
        private ushort LocalVariableTableLength { set; get; }
        private LocalVariableTable [] LocalVariableTables { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.LocalVariableTableLength = classData.ReadUint16();
            
            this.LocalVariableTables = new LocalVariableTable[this.LocalVariableTableLength];
            for (var i = 0; i < this.LocalVariableTableLength; i++)
            {
                this.LocalVariableTables[i] = new LocalVariableTable().Read(classData);
            }
        }
    }
}