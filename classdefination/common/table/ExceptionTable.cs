namespace csjvm.classdefination.common.table
{
    /// <summary>
    /// Code_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u2 max_stack;
    ///    u2 max_locals;
    ///    u4 code_length;
    ///    u1 code[code_length];
    ///    u2 exception_table_length;
    ///    {   u2 start_pc;
    ///        u2 end_pc;
    ///        u2 handler_pc;
    ///        u2 catch_type;
    ///    } exception_table[exception_table_length];
    ///    u2 attributes_count;
    ///    attribute_info attributes[attributes_count];
    /// }
    /// </summary>
    public class ExceptionTable : IReadable<ExceptionTable>
    {
        public ushort StartPc { set; get; }
        public ushort EndPc { set; get; }
        public ushort HandlerPc { set; get; }
        public ushort CatchType { set; get; }

        public ExceptionTable Read(ClassData classData)
        {
            this.StartPc = classData.ReadUint16();
            this.EndPc = classData.ReadUint16();
            this.HandlerPc = classData.ReadUint16();
            this.CatchType = classData.ReadUint16();

            return this;
        }
    }
}