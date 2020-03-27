using System;
using System.IO;
using csjvm.classdefination;
using csjvm.classdefination.command;
using csjvm.entry;
using csjvm.factory;

/// <summary>
/// 描述：类运行根目录
/// 创建者：ysdxz207
/// </summary>
namespace csjvm.util
{
    class Classpath
    {
        public IEntry BootClasspath { get; set; }
        public IEntry ExtClasspath { get; set; }
        public IEntry UserClasspath { get; set; }

        /// <summary>
        /// 解析classpath
        /// 1、解析bootClasspath
        /// 2、解析extClasspath
        /// 3、解析userClasspath
        /// </summary>
        /// <param name="jreOption"></param>
        /// <param name="classpathOption"></param>
        /// <returns></returns>
        public Classpath(CommandLine commandLine)
        {
            ParseBootAndExtClasspath(commandLine);
            ParseUserClasspath(commandLine);
        }

        /// <summary>
        /// 解析用户自定义的classpath
        /// </summary>
        /// <param name="classpathOption"></param>
        private void ParseUserClasspath(CommandLine commandLine)
        {
            if (string.IsNullOrEmpty(commandLine.UserClasspathInfo))
            {
                commandLine.UserClasspathInfo = ".";
            }
            this.UserClasspath = EntryFactory.GetEntry(commandLine.UserClasspathInfo);
        }

        /// <summary>
        /// 解析bootClasspath和extClasspath
        /// 分别是目录：jre/lib/
        /// </summary>
        /// <param name="jreOption"></param>
        private void ParseBootAndExtClasspath(CommandLine commandLine)
        {
            var jreDirectory = GetJreDirectory(commandLine);
            // jre/lib/*
            var jreLibPath = Path.Combine(jreDirectory, "lib", "*");
            BootClasspath = new WildcardEntry(jreLibPath);

            // jre/lib/ext/*
            var jreLibExtPath = Path.Combine(jreDirectory, "lib", "ext", "*");
            ExtClasspath = new WildcardEntry(jreLibExtPath);
        }

        /// <summary>
        /// 获取jre目录
        /// </summary>
        /// <param name="jreOption"></param>
        /// <returns></returns>
        private string GetJreDirectory(CommandLine commandLine)
        {
            // 用户自定义优先
            if (commandLine.IsUserJreOption && Directory.Exists(commandLine.UserJreInfo))
            {
                return commandLine.UserJreInfo;
            }

            // 当前目录下的.jre目录其次
            if (Directory.Exists(".jre"))
            {
                return ".jre";
            }

            // 最后是环境变量
            var javaHome = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (!String.IsNullOrEmpty(javaHome))
            {
                return Path.Combine(javaHome, "jre");
            }

            throw new Exception("Can not find jre directory!");
        }

        /// <summary>
        /// 自动判断并读取class二进制数据
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public ClassData ReadClass(string className)
        {
            try
            {
                return this.BootClasspath.ReadClass(className);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                try
                {
                    return this.ExtClasspath.ReadClass(className);
                }
                catch (Exception e1)
                {
                    return this.UserClasspath.ReadClass(className);
                }
            }
        }

        
    }

}
