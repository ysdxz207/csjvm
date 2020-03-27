using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 描述：不是java类抛出异常
/// 创建者：ysdxz207
/// </summary>
namespace csjvm.exception
{
    class NotClassFileException : Exception
    {
        public NotClassFileException(string message) : base(message)
        {
        }
    }
}
