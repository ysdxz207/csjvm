namespace csjvm.classdefination.common.frame.verification
{
    /// <summary>
    /// union verification_type_info {
    ///    Top_variable_info;
    ///    Integer_variable_info;
    ///    Float_variable_info;
    ///    Long_variable_info;
    ///    Double_variable_info;
    ///    Null_variable_info;
    ///    UninitializedThis_variable_info;
    ///    Object_variable_info;
    ///    Uninitialized_variable_info;
    /// }
    /// </summary>
    public class VerificationTypeInfo : IReadable<VerificationTypeInfo>
    {
        private TopVariableInfo TopVariableInfo { set; get; }
        private IntegerVariableInfo IntegerVariableInfo { set; get; }
        private FloatVariableInfo FloatVariableInfo { set; get; }
        private LongVariableInfo LongVariableInfo { set; get; }
        private DoubleVariableInfo DoubleVariableInfo { set; get; }
        private NullVariableInfo NullVariableInfo { set; get; }
        private UninitializedThisVariableInfo UninitializedThisVariableInfo { set; get; }
        private ObjectVariableInfo ObjectVariableInfo { set; get; }
        private UninitializedVariableInfo UninitializedVariableInfo { set; get; }

        public VerificationTypeInfo Read(ClassData classData)
        {
            var tag = classData.ReadUint8WithoutSub();
            switch (tag)
            {
                case 0:

                    this.TopVariableInfo = (TopVariableInfo) new TopVariableInfo().Read(classData);
                    break;
                case 1:

                    this.IntegerVariableInfo = (IntegerVariableInfo) new IntegerVariableInfo().Read(classData);
                    break;
                case 2:

                    this.FloatVariableInfo = (FloatVariableInfo) new FloatVariableInfo().Read(classData);
                    break;
                case 3:

                    this.DoubleVariableInfo = (DoubleVariableInfo) new DoubleVariableInfo().Read(classData);
                    break;
                case 4:
                    this.LongVariableInfo = (LongVariableInfo) new LongVariableInfo().Read(classData);

                    break;
                case 5:

                    this.NullVariableInfo = (NullVariableInfo) new NullVariableInfo().Read(classData);
                    break;
                case 6:

                    this.UninitializedThisVariableInfo =
                        (UninitializedThisVariableInfo) new UninitializedThisVariableInfo().Read(classData);
                    break;
                case 7:
                    this.ObjectVariableInfo = (ObjectVariableInfo) new ObjectVariableInfo().Read(classData);
                    break;

                case 8:
                    this.UninitializedVariableInfo =
                        (UninitializedVariableInfo) new UninitializedVariableInfo().Read(classData);
                    break;
            }

            return this;
        }
    }
}