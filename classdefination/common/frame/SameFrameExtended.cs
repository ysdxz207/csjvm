using csjvm.exception;

namespace csjvm.classdefination.common.frame
{
    /// <summary>
    /// same_frame_extended {
    ///     u1 frame_type = SAME_FRAME_EXTENDED; /* 251 */
    ///     u2 offset_delta;
    /// }
    /// </summary>
    public class SameFrameExtended : Frame
    {
        private ushort OffsetDelta { set; get; }

        public override IFrame ReadNotPublic(ClassData classData)
        {
            if (this.FrameType != 251)
            {
                throw new InvalidFrameTypeException("Invalid FrameType :" + this.FrameType);
            }
            this.OffsetDelta = classData.ReadUint16();
            
            return this;
        }
    }
}