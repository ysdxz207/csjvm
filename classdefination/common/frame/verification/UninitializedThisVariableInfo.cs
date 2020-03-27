namespace csjvm.classdefination.common.frame.verification
{
    /// <summary>
    /// UninitializedThis_variable_info {
    ///    u1 tag = ITEM_UninitializedThis; /* 6 */
    /// }
    /// </summary>
    public class UninitializedThisVariableInfo : VariableInfo
    {

        public override IVariableInfo ReadNotPublic(ClassData classData)
        {
            return this;
        }
    }
}