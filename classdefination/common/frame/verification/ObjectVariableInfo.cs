namespace csjvm.classdefination.common.frame.verification
{
    /// <summary>
    /// Object_variable_info {
    ///    u1 tag = ITEM_Object; /* 7 */
    ///    u2 cpool_index;
    /// }
    /// </summary>
    public class ObjectVariableInfo : VariableInfo
    {
        private ushort CpoolIndex { set; get; }

        public override IVariableInfo ReadNotPublic(ClassData classData)
        {
            this.CpoolIndex = classData.ReadUint16();
            return this;
        }
    }
}