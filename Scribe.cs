using Cassowary.Runtime;
using Rio.Emit;
using System.Text;

namespace Rio
{
    public class Scribe
    {
        public static StringBuilder Write(Function func)
        {
            if (func._tsoFrame.HasPrepared)
                return WriteRhea(func);

            return WriteDefault(func);
        }

        private static StringBuilder WriteDefault(Function func)
        {
            return new StringBuilder();
        }

        private static StringBuilder WriteRhea(Function func)
        {
            OpCode[] opcodes = Enum.GetValues<OpCode>();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < func._rhFrame.Data.Length; i++)
            {
                Instruction instr = new Instruction(opcodes[func._rhFrame.Data[i]]);

                stringBuilder.Append(i.ToString().PadLeft(3, '0'));
                stringBuilder.Append(' ');
                stringBuilder.Append(instr.OpCode.ToString());
                stringBuilder.Append(" [");
                stringBuilder.Append(instr.OpCount);
                stringBuilder.AppendLine("]");

                i += func._instructions[i].BlockSize;
            }

            return stringBuilder;
        }
    }
}
