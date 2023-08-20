namespace Rio.Emit
{
    [Flags]
    public enum Decor
    {
        /// <summary>
        /// Default behavior.
        /// </summary>
        none = 0,

        /// <summary>
        /// Modifies all registers.
        /// </summary>
        a = 8,
        /// <summary>
        /// Modifies the last used (current) register.
        /// </summary>
        f = 16,
        /// <summary>
        /// Modifies the next unused (next) register.
        /// </summary>
        n = 32,
        /// <summary>
        /// Modifies all personal registers.
        /// </summary>
        rp = 64,
        /// <summary>
        /// Modifies all call registers.
        /// </summary>
        cr = 128,
        /// <summary>
        /// Executes only if an additional 2 operands are equal.
        /// </summary>
        deq = 256,
        /// <summary>
        /// Executes only if an additional 2 operands are not equal.
        /// </summary>
        dneq = 512,
        /// <summary>
        /// Executes only if the former of an additional 2 operands is greater than the latter.
        /// </summary>
        dgt = 1024,
        /// <summary>
        /// Executes only if the former of an additional 2 operands is greater than or equal to the latter.
        /// </summary>
        dgeq = 2048,
        /// <summary>
        /// Executes only if the former of an additional 2 operands is lesser than the latter.
        /// </summary>
        dlt = 4096,
        /// <summary>
        /// Executes only if the former of an additional 2 operands is lesser than or equal to the latter.
        /// </summary>
        dleq = 8192,
        /// <summary>
        /// Executes only if 0 exceptions are on the exception stack.
        /// </summary>
        nex = 16384,
        /// <summary>
        /// Executes only if 1+ exceptions are on the exception stack.
        /// </summary>
        ex = 32768,
        /// <summary>
        /// Executes only if the comparative register (RCX) is equal to 1.
        /// </summary>
        eq = 65536,
        /// <summary>
        /// Executes only if the comparative register (RCX) is not equal to 1.
        /// </summary>
        neq = 131072,
        /// <summary>
        /// Rests after execution.
        /// </summary>
        cozy = 262144,
        /// <summary>
        /// Pushes any exceptions thrown onto the exception stack.
        /// </summary>
        atmpt = 524288,
        /// <summary>
        /// Bounces any exceptions thrown.
        /// </summary>
        bnc = 1048576
    }
}
