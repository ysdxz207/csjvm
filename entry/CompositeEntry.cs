using System;
using System.Collections.Generic;
using csjvm.classdefination;
using csjvm.exception;
using csjvm.factory;

/// <summary>
/// 描述：多个文件路径组合的读取
///         如：c:/a.class;c:/b.class
/// 创建者：ysdxz207
/// </summary>
namespace csjvm.entry
{
    class CompositeEntry : IEntry
    {
        private readonly List<IEntry> _entryList = new List<IEntry>();


        public CompositeEntry(string pathList)
        {
            foreach (var path in pathList.Split(";"))
            {
                _entryList.Add(EntryFactory.GetEntry(path));
            }
        }

        public ClassData ReadClass(string className)
        {
            // 只要有一个能访问到就可以
            foreach (var entry in _entryList)
            {
                try
                {
                    return entry.ReadClass(className);
                } catch(Exception)
                {
                    continue;
                }
            }

            throw new ClassNotFoundException("Can not found class:" + className);
        }
    }
}
