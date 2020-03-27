using System;

namespace csjvm.classdefination.common.frame
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Frame : IFrame
    {
        protected byte FrameType { set; get; }

        /// <summary>
        /// 读取非公共部分
        /// </summary>
        /// <param name="classData"></param>
        /// <returns></returns>
        public abstract IFrame ReadNotPublic(ClassData classData);
        
        /// <summary>
        /// 读取公共部分
        /// </summary>
        /// <param name="classData"></param>
        /// <returns></returns>
        public IFrame Read(ClassData classData)
        {
            this.FrameType = classData.ReadUint8();
            
            return ReadNotPublic(classData);
        }
    }
}