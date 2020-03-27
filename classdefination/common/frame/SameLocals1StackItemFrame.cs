using csjvm.classdefination.common.frame.verification;
using csjvm.exception;

namespace csjvm.classdefination.common.frame
{
    /// <summary>
    /// same_locals_1_stack_item_frame {
    ///     u1 frame_type = SAME_LOCALS_1_STACK_ITEM; /* 64-127 */
    ///     verification_type_info stack[1];
    /// }
    /// </summary>
    public class SameLocals1StackItemFrame : Frame
    {
        private VerificationTypeInfo Stack { set; get; }

        public override IFrame ReadNotPublic(ClassData classData)
        {
            if (this.FrameType < 64 || this.FrameType > 127)
            {
                throw new InvalidFrameTypeException("Invalid FrameType :" + this.FrameType);
            }
            
            this.Stack = new VerificationTypeInfo().Read(classData);
            return this;
        }
    }
}