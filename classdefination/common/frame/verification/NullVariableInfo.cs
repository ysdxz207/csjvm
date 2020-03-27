namespace csjvm.classdefination.common.frame.verification
{
    /// <summary>
    /// Null_variable_info {
    ///    u1 tag = ITEM_Null; /* 5 */
    /// }
    /// </summary>
    public class NullVariableInfo : VariableInfo
    {
        public override IVariableInfo ReadNotPublic(ClassData classData)
        {
            return this;
        }
    }
}