using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// Exceptions_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u2 number_of_exceptions;
    ///    u2 exception_index_table[number_of_exceptions];
    /// }
    ///
    /// exception_index_table:Each value in the exception_index_table array must be a valid index into the constant_pool table. 
    /// </summary>
    public class ExceptionsAttribute : AttributeInfo
    {
        private ushort NumberOfExceptions { set; get; }
        private ushort [] ExceptionIndexTables { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.NumberOfExceptions = classData.ReadUint16();
            this.ExceptionIndexTables = new ushort [this.NumberOfExceptions];
            for (var i = 0; i < this.NumberOfExceptions; i++)
            {
                this.ExceptionIndexTables[i] = classData.ReadUint16();
            }
        }
    }
}