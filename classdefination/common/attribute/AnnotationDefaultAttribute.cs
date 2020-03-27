using csjvm.classdefination.common.annotation;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// AnnotationDefault_attribute {
    ///    u2            attribute_name_index;
    ///    u4            attribute_length;
    ///    element_value default_value;
    ///}
    /// </summary>
    public class AnnotationDefaultAttribute : AbstractAttribute
    {
        private ElementValue DefaultValue { set; get; }


        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.DefaultValue = new ElementValue().Read(classData);
        }
    }
}