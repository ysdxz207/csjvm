using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common
{
    public interface IConstantPoolReadable<T>
    {
        public T Read(ClassData classData, ConstantPool constantPool);
    }
}