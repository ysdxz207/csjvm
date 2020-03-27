using csjvm.classdefination.common.attribute;
using csjvm.classdefination.common.reader;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// MethodParameters_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u1 parameters_count;
    ///    {   u2 name_index;
    ///        u2 access_flags;
    ///    } parameters[parameters_count];
    ///}
    /// </summary>
    public class MethodParametersAttribute : AttributeInfo
    {
        private ushort ParametersCount { set; get; }
        private Parameter [] Parameters { set; get; }


        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.ParametersCount = classData.ReadUint16();
            this.Parameters = new ParameterReader(classData).ReadParameters(this.ParametersCount);
        }
    }

    public class Parameter : IReadable<Parameter>
    {
        private ushort NameIndex { set; get; }
        private ushort AccessFlags { set; get; }
        public Parameter Read(ClassData classData)
        {
            this.NameIndex = classData.ReadUint16();
            this.AccessFlags = classData.ReadUint16();

            return this;
        }
    }
    
}