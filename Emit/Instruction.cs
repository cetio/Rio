namespace Rio.Emit
{
    public class Instruction
    {
        public OpCode OpCode { get; set; }
        public object?[] Operands { get; set; }
        public Variance Variance { get; internal set; }

        public Instruction(OpCode opcode, params object?[] operands)
        {
            OpCode = opcode;
            Operands = operands;
        }

        public int Identifier
        {
            get
            {
                return (int)((uint)OpCode >> 13) & 0xFF;
            }
        }

        public FlowControl FlowControl
        {
            get
            {
                return (FlowControl)(((uint)OpCode >> 10) & 0x07);
            }
        }

        public int OpCount
        {
            get
            {
                return (int)((uint)OpCode >> 7) & 0x07;
            }
        }

        public int BlockSize
        {
            get
            {
                return (int)((uint)OpCode >> 2) & 0x1F;
            }
        }

        public bool IsVariant
        {
            get
            {
                return ((uint)OpCode & 0x1) == 1;
            }
        }
    }
}
