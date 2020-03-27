using System.Text.Unicode;

namespace csjvm.classdefination.constantpool.impl
{
    /// <summary>
    /// CONSTANT_Utf8_info {
    ///    u1 tag;
    ///    u2 length;
    ///    u1 bytes[length];
    /// }
    /// </summary>
    public class ConstantUtf8Info : ConstantPoolInfo
    {
        public ushort Length { set; get; }
        public byte [] Bytes { set; get; }
        public string Value { set; get; }


        public override ConstantPoolInfo ReadNotPublic(ClassData classData, ConstantPool constantPool)
        {
            this.Length = classData.ReadUint16();
            this.Bytes = classData.ReadBytes(this.Length);
            this.Value = System.Text.Encoding.UTF8.GetString(this.Bytes);

            return this;
        }
    }
}