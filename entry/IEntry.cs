using csjvm.classdefination;

/// <summary>
/// 描述：入口接口，其中包含一个默认的NewEntry函数，用来创建一个访问入口
/// 创建者：ysdxz207
/// </summary>
namespace csjvm.entry
{
    interface IEntry
    {
        ClassData ReadClass(string className);
        string ToString();
    }
}
