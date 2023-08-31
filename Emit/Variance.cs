namespace Rio.Emit
{
    public enum Variance : byte
    {
        Invalid,
        /// <summary>
        /// The related OpCode is a castled call, meaning that it will fetch speculated parameters.
        /// </summary>
        Castled,
        /// <summary>
        /// The related OpCode is a register to register operation.
        /// </summary>
        RtR,
        /// <summary>
        /// The related OpCode is a register to objref operation.
        /// </summary>
        RtO,
        /// <summary>
        /// The related OpCode is a objref to register operation.
        /// </summary>
        OtR,
        /// <summary>
        /// The related OpCode is a objref to objref operation.
        /// </summary>
        OtO,
        /// <summary>
        /// The related OpCode is a register to 32 bit integer operation.
        /// </summary>
        Rti32,
        /// <summary>
        /// The related OpCode is a register to 64 bit integer operation.
        /// </summary>
        Rti64,
        /// <summary>
        /// The related OpCode can be assured to only take 32 bit integers.
        /// </summary>
        i32ti32,
        /// <summary>
        /// The related OpCode can be assured to only take 64 bit integers.
        /// </summary>
        i64ti64,
        Unknown
    }
}
