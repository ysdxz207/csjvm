using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// Signature_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u2 signature_index;
    ///}

    /// </summary>
    public class SignatureAttribute : AttributeInfo
    {
        private ushort SignatureIndex { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.SignatureIndex = classData.ReadUint16();
        }
    }
}