using csjvm.classdefination.common.reader;

namespace csjvm.classdefination.common.annotation
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
    public class ParameterAnotation : IReadable<ParameterAnotation>
    {
        private ushort NumAnnotations { set; get; }
        private Annotation [] Annotations { set; get; }
        public ParameterAnotation Read(ClassData classData)
        {
            this.NumAnnotations = classData.ReadUint16();
            this.Annotations = new AnnotationReader(classData).ReadAnnotations(this.NumAnnotations);

            return this;
        }
    }
}