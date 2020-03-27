using csjvm.classdefination.common.frame;

namespace csjvm.classdefination.common.reader
{
    public class StackMapFrameReader
    {
        
        private readonly ClassData _classData;

        public StackMapFrameReader(ClassData classData)
        {
            this._classData = classData;
        }


        public StackMapFrame[] ReadStackMapFrames(ushort numberOfEntries)
        {
            
            var stackMapFrames = new StackMapFrame[numberOfEntries];
            
            for (var i = 0; i < numberOfEntries; i++)
            {
                stackMapFrames[i] = new StackMapFrame().Read(_classData);
            }

            return stackMapFrames;
        }
    }
}