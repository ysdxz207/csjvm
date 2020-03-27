using csjvm.classdefination.common.frame.verification;
using csjvm.classdefination.common.reader;
using csjvm.exception;

namespace csjvm.classdefination.common.frame
{
    /// <summary>
    /// full_frame {
    ///     u1 frame_type = FULL_FRAME; /* 255 */
    ///     u2 offset_delta;
    ///     u2 number_of_locals;
    ///     verification_type_info locals[number_of_locals];
    ///     u2 number_of_stack_items;
    ///     verification_type_info stack[number_of_stack_items];
    /// }
    /// </summary>
    public class FullFrame : Frame
    {
        private ushort OffsetDelta { set; get; }
        private ushort NumberOfLocals { set; get; }
        private VerificationTypeInfo [] Locals { set; get; }
        private ushort NumberOfStackItems { set; get; }
        private VerificationTypeInfo [] Stacks { set; get; }


        public override IFrame ReadNotPublic(ClassData classData)
        {
            if (this.FrameType != 255)
            {
                throw new InvalidFrameTypeException("Invalid FrameType :" + this.FrameType);
            }
            this.OffsetDelta = classData.ReadUint16();
            this.NumberOfLocals = classData.ReadUint16();
            this.Locals = new VerificationTypeInfoReader(classData).ReadVerificationTypeInfos(this.NumberOfLocals);
            this.NumberOfStackItems = classData.ReadUint16();
            this.Stacks = new VerificationTypeInfoReader(classData).ReadVerificationTypeInfos(this.NumberOfStackItems);
            return this;
        }
    }
}