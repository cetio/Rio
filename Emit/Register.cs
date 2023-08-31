namespace Rio.Emit
{
    public enum Register
    {
        // 1-byte (low) registers
        AL,
        BL,
        CL,
        DL,
        R8B,
        R9B,
        R10B,
        R11B,
        R12B,
        R13B,
        R14B,
        R15B,

        // 2-byte (low) registers
        AX,
        BX,
        CX,
        DX,
        R8W,
        R9W,
        R10W,
        R11W,
        R12W,
        R13W,
        R14W,
        R15W,

        // 4-byte (low) registers
        EAX,
        EBX,
        ECX,
        EDX,
        R8D,
        R9D,
        R10D,
        R11D,
        R12D,
        R13D,
        R14D,
        R15D,

        // All registers have a byte at index 0 for flags
        // Parameters are pushed to registers 2-n
        // 8-byte registers
        RAX,
        RBX,
        RCX,
        RDX,
        R8,
        R9,
        R10,
        R11,
        R12,
        R13,
        R14,
        R15,

        // 16-byte registers
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

        // 32-byte registers
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

        // 80-byte registers
        ZMM0,
        ZMM1,
        ZMM2,
        ZMM3,
        ZMM4,
        ZMM5,
        ZMM6,
        ZMM7,
        ZMM8,
        ZMM9,
    }
}
