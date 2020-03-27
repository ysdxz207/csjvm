namespace csjvm.classdefination.common.frame
{
    /// <summary>
    /// union stack_map_frame {
    ///    same_frame;
    ///    same_locals_1_stack_item_frame;
    ///    same_locals_1_stack_item_frame_extended;
    ///    chop_frame;
    ///    same_frame_extended;
    ///    append_frame;
    ///    full_frame;
    /// }
    /// </summary>
    public class StackMapFrame : IReadable<StackMapFrame>
    {
        private SameFrame SameFrame { set; get; }
        private SameLocals1StackItemFrame SameLocals1StackItemFrame { set; get; }
        private SameLocals1StackItemFrameExtended SameLocals1StackItemFrameExtended { set; get; }
        private ChopFrame ChopFrame { set; get; }
        private SameFrameExtended SameFrameExtended { set; get; }
        private AppendFrame AppendFrame { set; get; }
        private FullFrame FullFrame { set; get; }

        public StackMapFrame Read(ClassData classData)
        {
            var frameType = classData.ReadUint8WithoutSub();


            if (frameType <= 63)
            {
                this.SameFrame = (SameFrame) new SameFrame().Read(classData);
            }
            else if (frameType >= 64 && frameType <= 127)
            {
                this.SameLocals1StackItemFrame =
                    (SameLocals1StackItemFrame) new SameLocals1StackItemFrame().Read(classData);
            }
            else if (frameType == 247)
            {
                this.SameLocals1StackItemFrameExtended =
                    (SameLocals1StackItemFrameExtended) new SameLocals1StackItemFrameExtended().Read(classData);
            }
            else if (frameType >= 248 && frameType <= 250)
            {
                this.ChopFrame = (ChopFrame) new ChopFrame().Read(classData);
            }
            else if (frameType == 251)
            {
                this.SameFrameExtended = (SameFrameExtended) new SameFrameExtended().Read(classData);
            }
            else if (frameType >= 252 && frameType <= 254)
            {
                this.AppendFrame = (AppendFrame) new AppendFrame().Read(classData);
            }
            else if (frameType == 255)
            {
                this.FullFrame = (FullFrame) new FullFrame().Read(classData);
            }


            return this;
        }
    }
}