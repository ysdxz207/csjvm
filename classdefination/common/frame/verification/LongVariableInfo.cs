namespace csjvm.classdefination.common.frame.verification
{
    /// <summary>
    /// Long_variable_info {
    ///    u1 tag = ITEM_Long; /* 4 */
    /// }
    /// </summary>
    public class LongVariableInfo : VariableInfo
    {
        public override IVariableInfo ReadNotPublic(ClassData classData)
        {
            return this;
        }
    }
}