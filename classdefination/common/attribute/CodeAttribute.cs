using csjvm.classdefination.common.reader;
using csjvm.classdefination.common.table;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
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
    public class CodeAttribute : AttributeInfo
    {
        private ushort MaxStack { set; get; }
        private ushort MaxLocals { set; get; }
        private uint CodeLength { set; get; }
        /// <summary>
        /// 原code是u1类型，表示code开始索引，从此索引读取CodeLength个
        /// </summary>
        private byte [] CodesIndex { set; get; }
        private ushort ExceptionTableLength { set; get; }
        private ExceptionTable[] ExceptionTable { set; get; }
        private uint AttributesCount { set; get; }
        private AttributeInfo[] Attributes { set; get; }


        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.MaxStack = classData.ReadUint16();
            this.MaxLocals = classData.ReadUint16();
            this.CodeLength = classData.ReadUint32();
            this.CodesIndex = new byte [this.CodeLength];
            for (var i = 0; i < this.CodeLength; i++)
            {
                this.CodesIndex [i] = classData.ReadUint8();
            }
            this.ExceptionTableLength = classData.ReadUint16();
            this.ExceptionTable = ReadExceptionTable(classData);
            this.AttributesCount = classData.ReadUint16();
            this.Attributes = new CommonAttributeReader(classData, constantPool).ReadAttributeInfos(this.AttributesCount);
        }


        private ExceptionTable[] ReadExceptionTable(ClassData classData)
        {
            var exceptionTables = new ExceptionTable [this.ExceptionTableLength];
            for (var i = 0; i < this.ExceptionTableLength; i++)
            {
                exceptionTables[i] = new ExceptionTable().Read(classData);
            }

            return exceptionTables;
        }
    }
}