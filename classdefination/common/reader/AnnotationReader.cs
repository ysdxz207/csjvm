using csjvm.classdefination.common.annotation;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.reader
{
    /// <summary>
    /// 
    /// </summary>
    public class AnnotationReader
    {
        private readonly ClassData _classData;

        public AnnotationReader(ClassData classData)
        {
            this._classData = classData;
        }


        public Annotation[] ReadAnnotations(ushort count)
        {
            var annotations = new Annotation[count];

            for (var i = 0; i < count; i++)
            {
                annotations[i] = new Annotation().Read(_classData);
            }

            return annotations;
        }
    }
}