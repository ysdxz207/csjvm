using csjvm.classdefination.common.frame.verification;
using csjvm.classdefination.common.reader;
using csjvm.exception;

namespace csjvm.classdefination.common.frame
{
    /// <summary>
    /// append_frame {
    ///     u1 frame_type = APPEND; /* 252-254 */
    ///     u2 offset_delta;
    ///     verification_type_info locals[frame_type - 251];
    /// }
    /// </summary>
    public class AppendFrame : Frame
    {
        private ushort OffsetDelta { set; get; }

        private VerificationTypeInfo[] Locals { set; get; }

        public override IFrame ReadNotPublic(ClassData classData)
        {
            if (this.FrameType < 252 || this.FrameType > 254)
            {
                throw new InvalidFrameTypeException("Invalid FrameType :" + this.FrameType);
            }
            this.OffsetDelta = classData.ReadUint16();
            this.Locals = new VerificationTypeInfoReader(classData).ReadVerificationTypeInfos(this.FrameType - 251);

            return this;
        }

    }
}