using System;

namespace csjvm.classdefination.common.table
{
    /// <summary>
    /// localvar_target {
    ///    u2 table_length;
    ///    {   u2 start_pc;
    ///        u2 length;
    ///        u2 index;
    ///    } table[table_length];
    ///}
    /// </summary>
    public class Table : IReadable<Table>
    {
        public ushort StartPc { set; get; }
        public ushort Length { set; get; }
        public ushort Index { set; get; }
        public Table Read(ClassData classData)
        {
            this.StartPc = classData.ReadUint16();
            this.Length = classData.ReadUint16();
            this.Index = classData.ReadUint16();

            return this;
        }
    }
}