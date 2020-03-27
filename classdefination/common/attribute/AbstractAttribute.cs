using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// 这里用了模版方法模式，先读取公共部分，再读各自的属性

    ///    u2 attribute_name_index;
    ///    u4 attribute_length;

    /// </summary>
    public abstract class AbstractAttribute : IAttribute
    {
        protected ushort AttributeNameIndex { set; get; }

        protected uint AttributeLength { set; get; }


        private void ReadPublic(ClassData classData)
        {
            this.AttributeNameIndex = classData.ReadUint16();
            this.AttributeLength = classData.ReadUint32();
        }

        /// <summary>
        /// 读取子属性信息
        /// </summary>
        /// <param name="classData"></param>
        /// <param name="constantPool"></param>
        protected abstract void ReadExtends(ClassData classData, ConstantPool constantPool);

        /// <summary>
        /// 读取属性信息，并且把属性的子属性信息也读取出来
        /// </summary>
        /// <param name="classData"></param>
        /// <param name="constantPool"></param>
        public void ReadWithExtends(ClassData classData, ConstantPool constantPool)
        {
            this.ReadPublic(classData);
            ReadExtends(classData, constantPool);
        }
    }
}