﻿namespace Rio.Emit
{
    public enum Variance : byte
    {
        None,
        /// <summary>
        /// The variance for the related OpCode means that it is a register to register operation.
        /// </summary>
        RtR,
        /// <summary>
        /// The variance for the related OpCode means that it is a register to objref operation.
        /// </summary>
        RtO,
        /// <summary>
        /// The variance for the related OpCode means that it is a objref to register operation.
        /// </summary>
        OtR,
        /// <summary>
        /// The variance for the related OpCode means that it is a objref to objref operation.
        /// </summary>
        OtO,
        /// <summary>
        /// The variance for the related OpCode can be assured to be all 32 bit integers.
        /// </summary>
        Fixed32,
        /// <summary>
        /// The variance for the related OpCode can be assured to be all 64 bit integers.
        /// </summary>
        Fixed64,
        Unknown
    }
}
