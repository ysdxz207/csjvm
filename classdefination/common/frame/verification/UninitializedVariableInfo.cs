namespace csjvm.classdefination.common.frame.verification
{
    /// <summary>
    /// Uninitialized_variable_info {
    ///    u1 tag = ITEM_Uninitialized; /* 8 */
    ///    u2 offset;
    /// }
    /// </summary>
    public class UninitializedVariableInfo : VariableInfo
    {
        private ushort Offset { set; get; }
        
        public override IVariableInfo ReadNotPublic(ClassData classData)
        {
            this.Offset = classData.ReadUint16();

            return this;
        }
    }
}