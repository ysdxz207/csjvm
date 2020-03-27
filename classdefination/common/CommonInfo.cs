using csjvm.classdefination.common.attribute;
using csjvm.classdefination.common.reader;
using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common
{
    /// <summary>
    /// 描述：Field，Method通用信息接口
    ///
    ///
    /// field_info {
    ///    u2             access_flags;
    ///    u2             name_index;
    ///    u2             descriptor_index;
    ///    u2             attributes_count;
    ///    attribute_info attributes[attributes_count];
    /// }
    ///
    /// method_info {
    ///    u2             access_flags;
    ///    u2             name_index;
    ///    u2             descriptor_index;
    ///    u2             attributes_count;
    ///    attribute_info attributes[attributes_count];
    /// }
    /// </summary>
    public class CommonInfo : IAttribute
    {
        public ushort AccessFlags { set; get; }
        public ushort NameIndex { set; get; }
        public ushort DescriptorIndex { set; get; }

        public ushort AttributesCount { set; get; }
        public AttributeInfo[] Attributes { set; get; }


        public void ReadWithExtends(ClassData classData, ConstantPool constantPool)
        {
            this.AccessFlags = classData.ReadUint16();
            this.NameIndex = classData.ReadUint16();
            this.DescriptorIndex = classData.ReadUint16();
            this.AttributesCount = classData.ReadUint16();
            this.Attributes = new CommonAttributeReader(classData, constantPool)
                .ReadAttributeInfos(this.AttributesCount);
        }
    }
}