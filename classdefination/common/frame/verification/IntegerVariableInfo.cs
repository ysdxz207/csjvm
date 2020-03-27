namespace csjvm.classdefination.common.frame.verification
{
    /// <summary>
    /// Integer_variable_info {
    ///    u1 tag = ITEM_Integer; /* 1 */
    /// }
    /// </summary>
    public class IntegerVariableInfo : VariableInfo
    {
        public override IVariableInfo ReadNotPublic(ClassData classData)
        {
            return this;
        }
    }
}