namespace Rio.Emit
{
    public enum Register
    {
        /// <summary>
        /// Execution pointer register.
        /// </summary>
        EAX,
        /// <summary>
        /// Contextual flags register.
        /// </summary>
        EBX,
        /// <summary>
        /// Comparison result register.
        /// </summary>
        ECX,

        // All registers store their personal flags in the first 4 bytes.
        // These registers will have the parameters for the function pushed to them.
        // 64-byte registers
        R7,
        R8,
        R9,
        R10,
        R11,
        R12,
        R13,
        R14,
        R15,
        // Extended set
        RAX,
        RBX,
        RCX,
        RDX,

        // 128-byte registers
        XMM0,
        XMM1,
        XMM2,
        XMM3,
        XMM4,
        XMM5,
        XMM6,
        XMM7,
        XMM8,
        XMM9,
        XMM10,

        // 256-byte registers
        YMM0,
        YMM1,
        YMM2,
        YMM3,
        YMM4,
        YMM5,
        YMM6,
        YMM7,
        YMM8,
        YMM9,
        YMM10
    }
}
