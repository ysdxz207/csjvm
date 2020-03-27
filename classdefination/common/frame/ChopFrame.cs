using csjvm.exception;

namespace csjvm.classdefination.common.frame
{
    /// <summary>
    /// chop_frame {
    ///     u1 frame_type = CHOP; /* 248-250 */
    ///     u2 offset_delta;
    /// }
    /// </summary>
    public class ChopFrame : Frame
    {
        private ushort OffsetDelta { set; get; }

        public override IFrame ReadNotPublic(ClassData classData)
        {
            if (this.FrameType < 248 || this.FrameType > 250)
            {
                throw new InvalidFrameTypeException("Invalid FrameType :" + this.FrameType);
            }
            this.OffsetDelta = classData.ReadUint16();
            
            return this;
        }
    }
}