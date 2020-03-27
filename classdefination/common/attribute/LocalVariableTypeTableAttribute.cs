using System.Threading;
using csjvm.classdefination.common.table;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// LocalVariableTypeTable_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u2 local_variable_type_table_length;
    ///    {   u2 start_pc;
    ///        u2 length;
    ///        u2 name_index;
    ///        u2 signature_index;
    ///        u2 index;
    ///    } local_variable_type_table[local_variable_type_table_length];
    ///}
    /// </summary>
    public class LocalVariableTypeTableAttribute : AttributeInfo
    {
        private ushort LocalVariableTypeTableLength { set; get; }
        private LocalVariableTypeTable [] LocalVariableTypeTables { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.LocalVariableTypeTableLength = classData.ReadUint16();

            this.LocalVariableTypeTables = new LocalVariableTypeTable[this.LocalVariableTypeTableLength];
            for (var i = 0; i < this.LocalVariableTypeTableLength; i++)
            {
                this.LocalVariableTypeTables[i] = new LocalVariableTypeTable().Read(classData);
            }
        }
    }
}