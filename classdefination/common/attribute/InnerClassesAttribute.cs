using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// InnerClasses_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u2 number_of_classes;
    ///    {   u2 inner_class_info_index;
    ///        u2 outer_class_info_index;
    ///        u2 inner_name_index;
    ///        u2 inner_class_access_flags;
    ///    } classes[number_of_classes];
    ///}
    /// </summary>
    public class InnerClassesAttribute : AttributeInfo
    {
        private ushort NumberOfClasses { set; get; }
        private Class [] Classes { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.NumberOfClasses = classData.ReadUint16();
            this.Classes = new Class [this.NumberOfClasses];
            for (var i = 0; i < this.NumberOfClasses; i++)
            {
                this.Classes[i] = new Class().Read(classData);
            }
        }


        class Class : IReadable<Class>
        {
            private ushort InnerClassInfoIndex { set; get; }
            private ushort OuterClassInfoIndex { set; get; }
            private ushort InnerNameIndex { set; get; }
            private ushort InnerClassAccessFlags { set; get; }
            public Class Read(ClassData classData)
            {

                this.InnerClassInfoIndex = classData.ReadUint16();
                this.OuterClassInfoIndex = classData.ReadUint16();
                this.InnerNameIndex = classData.ReadUint16();
                this.InnerClassAccessFlags = classData.ReadUint16();
                return this;
            }
        }
    }
}