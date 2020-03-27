using System;
using System.Linq;

namespace csjvm.classdefination
{
    /// <summary>
    /// 描述：定义一个类数据信息，用来储存类的字节数组
    /// 创建者：ysdxz027
    /// 时间：2020年3月3日 21:08:33
    /// </summary>
    public class ClassData
    {
        // class文件byte数组长度
        public int Length { set; get; }

        // byte数组
        public byte[] Data { set; get; }

        public ClassData(byte[] bytes)
        {
            this.Data = bytes;
            this.Length = bytes.Length;
        }

        /// <summary>
        /// 读取U1
        /// </summary>
        /// <returns></returns>
        public byte ReadUint8WithoutSub()
        {
            return this.Data[0];
        }
        

        /// <summary>
        /// 读取U1
        /// 读取后截取未读取部分并赋值给data
        /// </summary>
        /// <returns></returns>
        public byte ReadUint8()
        {
            var data = ReadUint8WithoutSub();
            this.Data = this.Data.Skip(1).Take(this.Length - 1).ToArray();
            this.Length = this.Data.Length;
            return data;
        }
        
        

        /// <summary>
        /// 读取U2
        /// 读取后截取未读取部分并赋值给data
        /// </summary>
        /// <returns></returns>
        public ushort ReadUint16WithoutSub()
        {
            return BitConverter.ToUInt16(GetEndianData(2));
        }
        
        /// <summary>
        /// 读取U2
        /// </summary>
        /// <returns></returns>
        public ushort ReadUint16()
        {
            var data = ReadUint16WithoutSub();
            this.Data = this.Data.Skip(2).Take(this.Length - 2).ToArray();
            this.Length = this.Data.Length;
            return data;
        }

        /// <summary>
        /// 读取U4
        /// 读取后截取未读取部分并赋值给data
        /// </summary>
        /// <returns></returns>
        public uint ReadUint32()
        {
            var data = BitConverter.ToUInt32(GetEndianData(4));
            this.Data = this.Data.Skip(4).Take(this.Length - 4).ToArray();
            this.Length = this.Data.Length;
            return data;
        }

        

        /// <summary>
        /// 
        /// 读取后截取未读取部分并赋值给data
        /// </summary>
        /// <returns></returns>
        public ulong ReadUint64()
        {
            var data = BitConverter.ToUInt64(GetEndianData(8));
            this.Data = this.Data.Skip(8).Take(this.Length - 8).ToArray();
            this.Length = this.Data.Length;
            return data;
        }
        
       
        /// <summary>
        /// 读取长度为length的byte数组
        /// 读取后截取未读取部分并赋值给data
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public byte [] ReadBytes(int length)
        {
            byte[] bytes = this.Data.Take(length).ToArray();
            this.Data = this.Data.Skip(length).Take(this.Length - length).ToArray();
            this.Length = this.Data.Length;
            return bytes;
        }
        
         
        /// <summary>
        /// 截取长度为length的大端数组
        /// 小端的CAFEBABE的顺序为：0xBE, 0xBA, 0xFE, 0xCA
        /// 大端的CAFEBABE的顺序为：0xCA, 0xFE, 0xBA, 0xBE
        /// </summary>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        private byte[] GetEndianData(int length)
        {
            var arr = this.Data.Take(length).ToArray();
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(arr);
            }

            return arr;
        }

    }
}