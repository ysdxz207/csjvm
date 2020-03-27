using csjvm.classdefination.common.annotation;
using csjvm.classdefination.common.reader;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// 通用
    /// </summary>
    public class CommonAnnotationAbstractAttribute : AttributeInfo
    {
        private ushort NumAnnotations { set; get; }
        private Annotation [] Annotations { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.NumAnnotations = classData.ReadUint16();
            this.Annotations = new AnnotationReader(classData).ReadAnnotations(this.NumAnnotations);
        }
    }
}