using csjvm.classdefination.common.attribute;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.reader
{
    public class ParameterReader
    {
        private readonly ClassData _classData;

        public ParameterReader(ClassData classData)
        {
            this._classData = classData;
        }
        
        
        public Parameter[] ReadParameters(ushort count)
        {
            var parameters = new Parameter[count];

            for (var i = 0; i < count; i++)
            {
                parameters[i] = new Parameter().Read(_classData);
            }

            return parameters;
        }
    }
}