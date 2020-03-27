using csjvm.classdefination.common.frame.verification;
using csjvm.exception;

namespace csjvm.classdefination.common.frame
{
    /// <summary>
    /// same_locals_1_stack_item_frame_extended {
    ///     u1 frame_type = SAME_LOCALS_1_STACK_ITEM_EXTENDED; /* 247 */
    ///     u2 offset_delta;
    ///     verification_type_info stack[1];
    /// }
    /// </summary>
    public class SameLocals1StackItemFrameExtended : Frame
    {
        private ushort OffsetDelta { set; get; }

        private VerificationTypeInfo Stack { set; get; }

        public override IFrame ReadNotPublic(ClassData classData)
        {
            if (this.FrameType != 247)
            {
                throw new InvalidFrameTypeException("Invalid FrameType :" + this.FrameType);
            }
            
            this.OffsetDelta = classData.ReadUint16();
            this.Stack = new VerificationTypeInfo().Read(classData);

            return this;
        }
    }
}