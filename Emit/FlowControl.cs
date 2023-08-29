namespace Rio.Emit
{
    public enum FlowControl
    {
        Next = 0,
        Return = 1,
        UnconditionalBranch = 2,
        ConditionalBranch = 3,
        Call = 4,
        XBeginXEnd = 5,
        Exception = 6,
        Halt = 7
    }
}
