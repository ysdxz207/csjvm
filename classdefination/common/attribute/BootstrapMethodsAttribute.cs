using csjvm.classdefination.constantpool;

namespace csjvm.classdefination.common.attribute
{
    /// <summary>
    /// BootstrapMethods_attribute {
    ///    u2 attribute_name_index;
    ///    u4 attribute_length;
    ///    u2 num_bootstrap_methods;
    ///    {   u2 bootstrap_method_ref;
    ///        u2 num_bootstrap_arguments;
    ///        u2 bootstrap_arguments[num_bootstrap_arguments];
    ///    } bootstrap_methods[num_bootstrap_methods];
    ///}
    /// </summary>
    public class BootstrapMethodsAttribute : AbstractAttribute
    {
        private ushort NumBootstrapMethods { set; get; }
        private BootstrapMethod[] BootstrapMethods { set; get; }

        protected override void ReadExtends(ClassData classData, ConstantPool constantPool)
        {
            this.NumBootstrapMethods = classData.ReadUint16();

            var bootstrapMethods = new BootstrapMethod [this.NumBootstrapMethods];
            for (var i = 0; i < this.NumBootstrapMethods; i++)
            {
                bootstrapMethods[i] = new BootstrapMethod().Read(classData);
            }

            this.BootstrapMethods = bootstrapMethods;
        }

        /// <summary>
        /// BootstrapMethods_attribute {
        ///    u2 attribute_name_index;
        ///    u4 attribute_length;
        ///    u2 num_bootstrap_methods;
        ///    {   u2 bootstrap_method_ref;
        ///        u2 num_bootstrap_arguments;
        ///        u2 bootstrap_arguments[num_bootstrap_arguments];
        ///    } bootstrap_methods[num_bootstrap_methods];
        /// }
        /// </summary>
        public class BootstrapMethod : IReadable<BootstrapMethod>
        {
            private ushort BootstrapMethodRef { set; get; }
            private ushort NumBootstrapArguments { set; get; }
            private ushort BootstrapArguments { set; get; }


            
            public BootstrapMethod Read(ClassData classData)
            {
                this.BootstrapMethodRef = classData.ReadUint16();
                this.NumBootstrapArguments = classData.ReadUint16();
                this.BootstrapArguments = classData.ReadUint16();

                return this;
            }
        }
    }
}