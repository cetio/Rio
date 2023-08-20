namespace Rio.Emit
{
    public enum FlowControl
    {
        Next = 0,
        Return = 8,
        UnconditionalBranch = 16,
        ConditionalBranch = 28,
        Call = 32,
        XBeginXEnd = 64,
        Exception = 128,
        Halt = 256
    }
}