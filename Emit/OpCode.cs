namespace Rio.Emit
{
    public enum OpCode : uint
    {
        Nop = 0x0,
        Ret = 0x2400,        // FlowControl.Return, 0 Operand, BlockSize 0, No Variance
        Halt = 0x5C00,       // FlowControl.Halt,   0 Operand, BlockSize 0, No Variance
        Call = 0x7000,       // FlowControl.Call,   0 Operand, BlockSize 0, No Variance
        Jmp = 0x8890,        // FlowControl.UnconditionalBranch, 1 Operand, BlockSize 4, No Variance (AIP)
        Jneq = 0xAC90,       // FlowControl.ConditionalBranch,   1 Operand, BlockSize 4, No Variance (AIP)
        Jeq = 0xCC90,        // FlowControl.ConditionalBranch,   1 Operand, BlockSize 4, No Variance (AIP)
        Jex = 0xEC90,        // FlowControl.ConditionalBranch,   1 Operand, BlockSize 4, No Variance (AIP)
        Jnex = 0x10C90,      // FlowControl.ConditionalBranch,   1 Operand, BlockSize 4, No Variance (AIP)
        Jgt = 0x12C90,       // FlowControl.ConditionalBranch,   1 Operand, BlockSize 4, No Variance (AIP)
        Jlt = 0x14C90,       // FlowControl.ConditionalBranch,   1 Operand, BlockSize 4, No Variance (AIP)
        Jgeq = 0x16C90,      // FlowControl.ConditionalBranch,   1 Operand, BlockSize 4, No Variance (AIP)
        Jleq = 0x18C90,      // FlowControl.ConditionalBranch,   1 Operand, BlockSize 4, No Variance (AIP)
        Abs = 0x1A090,       // FlowControl.Next, 1 Operand, BlockSize 4,  No Variance (Register)
        Add = 0x1C121,       // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance
        And = 0x1E121,       // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance
        Sub = 0x20121,       // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance
        Mul = 0x22121,       // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance
        Div = 0x24121,       // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance
        Neg = 0x26090,       // FlowControl.Next, 1 Operand, BlockSize 16, No Variance (Register)
        /// <summary>
        /// Bitwise not.
        /// </summary>
        Not = 0x28121,       // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance
        /// <summary>
        /// Bitwise or.
        /// </summary>
        Or = 0x2A121,        // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance
        /// <summary>
        /// Bitwise xor.
        /// </summary>
        Xor = 0x2C121,       // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance
        /// <summary>
        /// Bitwise shift left.
        /// </summary>
        Shl = 0x2E121,       // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance
        /// <summary>
        /// Bitwise shift right.
        /// </summary>
        Shr = 0x30121,       // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance
        /// <summary>
        /// Boxes an object from a provided pointer in memory.
        /// </summary>
        Ldobj = 0x32000,
        /// <summary>
        /// Casts an object to a provided type.
        /// </summary>
        Cast = 0x34141,      // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance (*, MethodTable*)
        /// <summary>
        /// Gets the size of a provided object.
        /// </summary>
        Sizeof = 0x360A1,    // FlowControl.Next, 1 Operand, BlockSize 8,  Has Variance (*)
        /// <summary>
        /// Creates an allocated instance of the provided type, executing the constructor fitting the parameters provided.
        /// </summary>
        Newobj = 0x380A0,    // FlowControl.Next, 1 Operand, BlockSize 8,  No Variance (MethodTable*)
        /// <summary>
        /// Creates an allocated null instance of a provided type, 
        /// </summary>
        Ldnull = 0x3A0A0,    // FlowControl.Next, 1 Operand, BlockSize 8,  No Variance (MethodTable*)
        Ceq = 0x3C131,       // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance (*)
        Cneq = 0x3E131,      // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance (*)
        Cex = 0x40000,       // FlowControl.Next, 0 Operand, BlockSize 0,  No Variance
        Cnex = 0x42000,      // FlowControl.Next, 0 Operand, BlockSize 0,  No Variance
        Cgt = 0x44131,       // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance (*)
        Clt = 0x46131,       // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance (*)
        Cgeq = 0x48131,      // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance (*)
        Cleq = 0x4A131,      // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance (*)
        Param = 0x4C0A1,     // FlowControl.Next, 1 Operand, BlockSize 8,  Has Variance (*)
        Mov = 0x4E141,       // FlowControl.Next, 2 Operand, BlockSize 16, Has Variance
        Pop = 0x50090,       // FlowControl.Next, 1 Operand, BlockSize 4,  No Variance
    }
}
