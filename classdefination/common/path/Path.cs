namespace csjvm.classdefination.common.path
{
    public class Path : IReadable<Path>

    {
        private byte TypePathKind { set; get; }
        private byte TypeArgumentIndex { set; get; }

        public Path Read(ClassData classData)
        {
            this.TypePathKind = classData.ReadUint8();
            this.TypeArgumentIndex = classData.ReadUint8();

            return this;
        }
    }
}