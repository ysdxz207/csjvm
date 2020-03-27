using csjvm.classdefination.common.frame.verification;

namespace csjvm.classdefination.common.reader
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
    public class VerificationTypeInfoReader
    {
        private readonly ClassData _classData;

        public VerificationTypeInfoReader(ClassData classData)
        {
            this._classData = classData;
        }


        public VerificationTypeInfo[] ReadVerificationTypeInfos(int count)
        {
            var verificationTypeInfos = new VerificationTypeInfo[count];
            for (var i = 0; i < count; i++)
            {
                verificationTypeInfos[i] = new VerificationTypeInfo().Read(_classData);
            }

            return verificationTypeInfos;
        }
    }
}