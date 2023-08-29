using Rio.Emit;

namespace Rio.Runtime
{
    internal unsafe struct ContextFrame
    {
        public readonly Register[] Registers;
        public Instruction* Pointer;

        public void Reset()
        {
            Pointer = null;
        }
    }
}
