namespace csjvm.classdefination.common.frame.verification
{
    /// <summary>
    /// Float_variable_info {
    ///    u1 tag = ITEM_Float; /* 2 */
    /// }
    /// </summary>
    public class FloatVariableInfo : VariableInfo
    {
        public override IVariableInfo ReadNotPublic(ClassData classData)
        {
            return this;
        }
    }
}