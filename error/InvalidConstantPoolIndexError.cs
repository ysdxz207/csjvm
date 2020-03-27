using csjvm.error;

namespace csjvm.exception
{
    /// <summary>
    /// 描述：无效的常量池索引
    /// 创建者：ysdxz207
    /// </summary>
    public class InvalidConstantPoolIndexError : Error
    {
        public InvalidConstantPoolIndexError(string message) : base(message)
        {
        }
    }
}