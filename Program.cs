using csjvm.classdefination.command;

/// <summary>
/// 描述：仅支持到java8
/// 创建者：ysdxz207
/// </summary>
namespace csjvm
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[1];
            args[0] = "java.lang.String";
            // 解析命令行参数
            var cmd = new CommandLine(args);
            
            // 执行命令行
            cmd.Execute();
        }
    }
}