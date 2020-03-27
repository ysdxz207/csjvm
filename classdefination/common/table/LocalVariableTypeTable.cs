namespace csjvm.classdefination.common.table
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
    public class LocalVariableTypeTable : LineNumberTable
    {
        public ushort NameIndex { set; get; }
        public ushort DescriptorIndex { set; get; }
        public ushort SignatureIndex { set; get; }
        public ushort Index { set; get; }
        
        public LocalVariableTypeTable Read(ClassData classData)
        {
            base.Read(classData);

            this.NameIndex = classData.ReadUint16();
            this.DescriptorIndex = classData.ReadUint16();
            this.SignatureIndex = classData.ReadUint16();
            this.Index = classData.ReadUint16();

            return this;
        }
        
    }
}