using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common
{
    public interface IReadable<T>
    {
        public T Read(ClassData classData);
    }
}