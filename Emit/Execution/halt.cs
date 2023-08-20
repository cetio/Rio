using System.Runtime.CompilerServices;

namespace Rio.Emit
{
    public class halt : Instruction, IOpCode
    {
        public new ClusterBehavior ClusterBehavior { get; } = ClusterBehavior.Inattentive;
        public new FlowControl FlowControl { get; } = FlowControl.Halt;
        public new int OpCount { get; set; } = 0;
        public new OpKind Op0Kind { get; } = OpKind.None;
        public new OpKind Op1Kind { get; } = OpKind.None;
        public new OpKind Op2Kind { get; } = OpKind.None;
        public new OpKind Op3Kind { get; } = OpKind.None;
        public new OpKind Op4Kind { get; } = OpKind.None;
        public new OpKind Op5Kind { get; } = OpKind.None;

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public halt(params object?[] operands) : base(operands) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public void Run() { }
    }
}
