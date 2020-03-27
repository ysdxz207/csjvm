using csjvm.classdefination.common.annotation;
using csjvm.classdefination.common.attribute;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.reader
{
    /// <summary>
    /// 
    /// </summary>
    public class TypeAnnotationReader
    {
        private readonly ClassData _classData;

        public TypeAnnotationReader(ClassData classData)
        {
            this._classData = classData;
        }


        public TypeAnnotation[] ReadAnnotations(ushort count)
        {
            var typeAnnotations = new TypeAnnotation[count];

            for (var i = 0; i < count; i++)
            {
                typeAnnotations[i] = new TypeAnnotation().Read(_classData);
            }

            return typeAnnotations;
        }
    }
}