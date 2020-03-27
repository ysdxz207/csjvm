using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// 描述：定义抽象属性
    /// </summary>
    public interface IAttribute
    {
        public void ReadWithExtends(ClassData classData, ConstantPool constantPool);
    }
}