using Rio.Emit;

namespace Rio.Runtime.Rhea
{
    internal class RuntimeHelpers
    {
        public static void PrepareFrame(List<Instruction> instructions, ref RheaFrame rhFrame)
        {
            foreach (Instruction instruction in instructions)
            {
                rhFrame.TotalBlockSize += instruction.BlockSize;
                rhFrame.NumInstructions++;

                if (instruction.IsVariant)
                    rhFrame.NumVariants++;
            }

            rhFrame.HasPrepared = true;
            rhFrame.Data = new byte[rhFrame.TotalBlockSize];
        }

        public static void PrepareVariants(List<Instruction> instructions)
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

                if (instruction.Operands[0].GetType().IsPrimitive || instruction.Operands[1].GetType().IsPrimitive)
                {
                    instruction.Variance = Variance.Unknown;
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

                instruction.Variance = Variance.OtO;
            }
        }

        public static void SetupFrame(List<Instruction> instructions, ref RheaFrame rhFrame)
        {
            
        }
    }
}
