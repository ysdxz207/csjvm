namespace csjvm.error
{
    /// <summary>
    /// 类格式不正确抛出错误
    /// </summary>
    public class ClassFormatError : Error
    {
        public ClassFormatError(string message) : base(message)
        {
        }
    }
}