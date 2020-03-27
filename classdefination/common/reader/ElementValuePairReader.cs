using csjvm.classdefination.common.annotation;

namespace csjvm.classdefination.common.reader
{
    /// <summary>
    /// 
    /// </summary>
    public class ElementValuePairReader
    {

        private readonly ClassData _classData;

        public ElementValuePairReader(ClassData classData)
        {
            _classData = classData;
        }

        public ElementValuePair[] ReadElementValuePairs(ushort count)
        {
            var elementValuePairs = new ElementValuePair[count];

            for (var i = 0; i < count; i++)
            {
                elementValuePairs[i] = new ElementValuePair().Read(this._classData);
            }

            return elementValuePairs;
        }
    }
}