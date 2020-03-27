using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 描述：找不到类抛出异常
/// 创建者：ysdxz207
/// </summary>
namespace csjvm.exception
{
    class ClassNotFoundException : Exception
    {
        public ClassNotFoundException(string message) : base(message)
        {
        }
    }
}
