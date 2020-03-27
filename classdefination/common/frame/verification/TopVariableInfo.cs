namespace csjvm.classdefination.common.frame.verification
{
    /// <summary>
    /// Top_variable_info {
    ///    u1 tag = ITEM_Top; /* 0 */
    /// }
    /// </summary>
    public class TopVariableInfo : VariableInfo
    {
        public override IVariableInfo ReadNotPublic(ClassData classData)
        {
            return this;
        }
    }
}