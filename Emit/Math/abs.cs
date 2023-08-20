using System.Runtime.CompilerServices;

namespace Rio.Emit
{
    public class abs : Instruction, IOpCode
    {
        public new ClusterBehavior ClusterBehavior { get; } = ClusterBehavior.Cycle;
        public new FlowControl FlowControl { get; } = FlowControl.Next;
        public new int OpCount { get; set; } = 1;
        public new OpKind Op0Kind { get; } = OpKind.Register;
        public new OpKind Op1Kind { get; } = OpKind.None;
        public new OpKind Op2Kind { get; } = OpKind.None;
        public new OpKind Op3Kind { get; } = OpKind.None;
        public new OpKind Op4Kind { get; } = OpKind.None;
        public new OpKind Op5Kind { get; } = OpKind.None;

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public abs(params object?[] operands) : base(operands) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Run()
        {
            // this is bad, rp should = abs(rp) not rp = abs(value)
            NativeOperands[0].Unbox().Value = Math.Abs(NativeOperands[0].Unbox());
        }
    }
}
