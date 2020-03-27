using csjvm.classdefination.common.annotation;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// RuntimeVisibleParameterAnnotations_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u1 num_parameters;
    ///    {   u2         num_annotations;
    ///        annotation annotations[num_annotations];
    ///    } parameter_annotations[num_parameters];
    ///}
    /// </summary>
    public class RuntimeVisibleParameterAnnotationsAttribute : AttributeInfo
    {
        private ushort NumParameters { set; get; }
        private ParameterAnotation [] ParameterAnnotations { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.NumParameters = classData.ReadUint16();
            
            var parameterAnnotations = new ParameterAnotation[this.NumParameters];

            for (var i = 0; i < this.NumParameters; i++)
            {
                parameterAnnotations[i] = new ParameterAnotation().Read(classData);
            }
            
            this.ParameterAnnotations = parameterAnnotations;
        }
    }

}