using csjvm.classdefination.common.attribute;
using csjvm.classdefination.common.reader;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// RuntimeInvisibleTypeAnnotations_attribute {
    ///    u2              attribute_name_index;
    ///    u4              attribute_length;
    ///    u2              num_annotations;
    ///    type_annotation annotations[num_annotations];
    ///}
    /// </summary>
    public class RuntimeInvisibleTypeAnnotationsAttribute : AttributeInfo
    {
        private ushort NumAnnotations { set; get; }
        private TypeAnnotation [] Annotations { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.NumAnnotations = classData.ReadUint16();
            this.Annotations = new TypeAnnotationReader(classData).ReadAnnotations(this.NumAnnotations);
        }
    }
}