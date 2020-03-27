using csjvm.exception;

namespace csjvm.classdefination.common.frame
{
    /// <summary>
    /// same_frame {
    ///     u1 frame_type = SAME; /* 0-63 */
    /// }
    /// </summary>
    public class SameFrame : Frame
    {
        public override IFrame ReadNotPublic(ClassData classData)
        {
            if (this.FrameType > 63)
            {
                throw new InvalidFrameTypeException("Invalid FrameType :" + this.FrameType);
            }
            return this;
        }
    }
}