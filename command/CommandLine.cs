using System;
using csjvm.classdefination.definer;
using csjvm.util;

/// <summary>
/// 描述：接收调用jvm命令用
/// 创建者：ysdxz207
/// 创建日期：2020年3月2日
/// </summary>
namespace csjvm.classdefination.command
{
    class CommandLine
    {
        // 帮助选项，就是平时我们输入help回车后告诉你怎么用
        public bool IsHelp { get; set; }

        // 版本选项，同上，返回版本信息
        public bool IsVersion { get; set; }

        // 用户是否自定义classpath信息
        public bool IsUserClasspath { get; set; }

        // 用户指定classpath参数选项
        public string UserClasspathInfo { get; set; }

        // 用户是否自定义jreOption
        public bool IsUserJreOption { get; set; }

        // 用户指定jre参数选项
        public string UserJreInfo { get; set; }

        // 指定要执行的java编译后的class文件
        public string ClassName { get; set; }

        // 指定运行参数
        public string[] Args { get; set; }


        public CommandLine(string[] args)
        {
            // 解析命令行
            ParseCommandLine(args);
        }

        public void Execute()
        {
            if (this.IsHelp)
            {
                Help.PrintHelp();
                Environment.Exit(0);
            }

            if (this.IsVersion)
            {
                Help.PrintVersion();
                Environment.Exit(0);
            }

            // 解析classpath
            var classData = new Classpath(this)
                .ReadClass(this.ClassName);
            // Console.WriteLine(BitConverter.ToString(classData.Data));
            // 定义类
            var classDefinition = new ClassDefiner(classData)
                .Define();
            
            Console.WriteLine("");
        }

        private void ParseCommandLine(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    this.IsHelp = true;
                    return;
                case 1:
                    switch (args[0])
                    {
                        case "-help":
                        case "-h":
                            this.IsHelp = true;
                            break;
                        case "-version":
                        case "-v":
                            this.IsVersion = true;
                            break;

                        default:
                            this.ClassName = ConvertPackageClassNameToPathClassName(args[0]);
                            break;
                    }

                    return;
            }

            if (args.Length <= 1) return;
            var indexClasspath = Array.IndexOf(args, "-cp");
            var indexJre = Array.IndexOf(args, "-jre");

            if (args[0] != null && args[0] != "")
            {
                this.ClassName = ConvertPackageClassNameToPathClassName(args[0]);
            }

            if (indexClasspath != -1)
            {
                indexClasspath += 1;
                if (indexClasspath > args.Length - 1)
                {
                    this.UserClasspathInfo = ".";
                }
                else
                {
                    this.UserClasspathInfo = args[indexClasspath];
                }

                this.IsUserClasspath = true;
            }

            if (indexJre != -1)
            {
                indexJre += 1;
                this.UserJreInfo = indexJre > args.Length - 1 ? "" : args[indexJre];

                this.IsUserJreOption = true;
            }

            var indexArgsStart = Math.Max(indexClasspath, indexJre) + 1;
            var argsLength = args.Length - indexArgsStart;

            if (argsLength <= 0) return;
            this.Args = new string[argsLength];
            Array.ConstrainedCopy(args, indexArgsStart, this.Args, 0, argsLength);
        }

        private string ConvertPackageClassNameToPathClassName(string packageClassName)
        {
            return packageClassName.Replace(".", "/") + ".class";
        }
    }
}