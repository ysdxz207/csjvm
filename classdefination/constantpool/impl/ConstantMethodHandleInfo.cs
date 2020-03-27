namespace csjvm.classdefination.constantpool.impl
{
    
    public class ConstantMethodHandleInfo : ConstantPoolInfo
    {
        
        private byte ReferenceKind { set; get; }

        private ushort ReferenceIndex { set; get; }

        public override ConstantPoolInfo ReadNotPublic(ClassData classData, ConstantPool constantPool)
        {
            this.ReferenceKind = classData.ReadUint8();
            this.ReferenceIndex = classData.ReadUint16();
            return this;
        }
    }
}