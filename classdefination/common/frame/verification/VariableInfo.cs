namespace csjvm.classdefination.common.frame.verification
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class VariableInfo : IVariableInfo
    {
        private byte Tag { set; get; }

        /// <summary>
        /// 读取非公共部分
        /// </summary>
        /// <param name="classData"></param>
        /// <returns></returns>
        public abstract IVariableInfo ReadNotPublic(ClassData classData);
        
        /// <summary>
        /// 读取功能部分
        /// </summary>
        /// <param name="classData"></param>
        /// <returns></returns>
        public IVariableInfo Read(ClassData classData)
        {
            this.Tag = classData.ReadUint8();
            return ReadNotPublic(classData);
        }
    }
}