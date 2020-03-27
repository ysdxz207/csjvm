using System;
using System.Collections.Generic;
using System.Text;
using csjvm.error;

/// <summary>
/// 描述：不是java类抛出错误
/// 创建者：ysdxz207
/// </summary>
namespace csjvm.exception
{
    class UnsupportedClassVersionError : Error
    {
        public UnsupportedClassVersionError(string message) : base(message)
        {
        }
    }
}
