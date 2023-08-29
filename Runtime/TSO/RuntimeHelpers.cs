using Rio.Emit;

namespace Rio.Runtime.TSO
{
    internal class RuntimeHelpers
    {
        public static void PrepareFrame(List<Instruction> instructions, ref TSOFrame tsoFrame)
        {
            foreach (Instruction instruction in instructions)
            {
                tsoFrame.TotalBlockSize += instruction.BlockSize;
                tsoFrame.NumInstructions++;

                if (instruction.IsVariant)
                    tsoFrame.NumVariants++;
            }

            tsoFrame.HasPrepared = true;
            tsoFrame.Data = new byte[tsoFrame.TotalBlockSize];
        }

        public static void PrepareVariants(List<Instruction> instructions, ref TSOFrame tsoFrame)
        {
            foreach (Instruction instruction in instructions)
            {
                if (!instruction.IsVariant)
                    continue;
                
                if (instruction.Operands[0] is int && instruction.Operands[1] is int)
                {
                    instruction.Variance = Variance.Fixed32;
                    break;
                }
                    
                if (instruction.Operands[0] is long && instruction.Operands[1] is long)
                {
                    instruction.Variance = Variance.Fixed64;
                    break;
                }

                if (instruction.Operands[0] is Emit.Register && instruction.Operands[1] is Emit.Register)
                {
                    instruction.Variance = Variance.RtR;
                    break;
                }

                if (instruction.Operands[0] is Emit.Register)
                {
                    instruction.Variance = Variance.RtO;
                    break;
                }

                if (instruction.Operands[1] is Emit.Register)
                {
                    instruction.Variance = Variance.OtR;
                    break;
                }

                if (instruction.Operands[0].GetType().IsPrimitive || instruction.Operands[1].GetType().IsPrimitive)
                {
                    instruction.Variance = Variance.Unknown;
                    break;
                }

                instruction.Variance = Variance.OtO;
            }
        }
    }
}
