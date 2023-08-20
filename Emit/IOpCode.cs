namespace Rio.Emit
{
    internal interface IOpCode
    {
        public ClusterBehavior ClusterBehavior { get; }
        public FlowControl FlowControl { get; }
        public int OpCount { get; set; }
        public OpKind Op0Kind { get; }
        public OpKind Op1Kind { get; }
        public OpKind Op2Kind { get; }
        public OpKind Op3Kind { get; }
        public OpKind Op4Kind { get; }
        public OpKind Op5Kind { get; }

        public void Run();
    }
}
