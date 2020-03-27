using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 描述：无效的FrameType
/// 创建者：ysdxz207
/// </summary>
namespace csjvm.exception
{
    class InvalidFrameTypeException : Exception
    {
        public InvalidFrameTypeException(string message) : base(message)
        {
        }
    }
}
