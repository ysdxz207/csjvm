namespace csjvm.classdefination.common.frame.verification
{
    /// <summary>
    /// Double_variable_info {
    ///    u1 tag = ITEM_Double; /* 3 */
    /// }
    /// </summary>
    public class DoubleVariableInfo : VariableInfo
    {
        public override IVariableInfo ReadNotPublic(ClassData classData)
        {
            return this;
        }
    }
}