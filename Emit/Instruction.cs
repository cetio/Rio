using Rio.Core.Data;
using System.Runtime.CompilerServices;

namespace Rio.Emit
{
    public class Instruction
    {
        public object?[] Operands { get; }
        internal Core.Data.Register[] NativeOperands { get; }

        /// <summary>
        /// Mnemonic of the provided Instruction, this is includes any Decor.
        /// </summary>
        public string Mnemonic
        {
            get
            {
                return (this as IOpCode).GetType().Name +
                    string.Join(string.Empty, Enum.GetValues(typeof(Decor)).Cast<Decor>().Where(x => x != Decor.none && Decor.HasFlag(x)));
            }
        }

        /// <summary>
        /// The Engine Decor of the related OpCode.
        /// </summary>
        public Decor Decor { get; internal set; }
        /// <summary>
        /// Behavior that the related OpCode exhibits when encountering a cluster of Registers. 
        /// </summary>
        public ClusterBehavior ClusterBehavior { get; }
        /// <summary>
        /// How the related OpCode modifies the Engine RIP after execution.
        /// </summary>
        public FlowControl FlowControl { get { return (this as IOpCode).FlowControl; } }

        /// <summary>
        /// The number of operands that the related OpCode is intended to parse.
        /// </summary>
        public int OpCount { get { return (this as IOpCode).OpCount; } }

        /// <summary>
        /// The OpKind of Operand 0. This is OpKind.None by default (absence of Operand.)
        /// </summary>
        public OpKind Op0Kind { get { return (this as IOpCode).Op0Kind; } }
        /// <summary>
        /// The OpKind of Operand 1. This is OpKind.None by default (absence of Operand.)
        /// </summary>
        public OpKind Op1Kind { get { return (this as IOpCode).Op1Kind; } }
        /// <summary>
        /// The OpKind of Operand 2. This is OpKind.None by default (absence of Operand.)
        /// </summary>
        public OpKind Op2Kind { get { return (this as IOpCode).Op2Kind; } }
        /// <summary>
        /// The OpKind of Operand 3. This is OpKind.None by default (absence of Operand.)
        /// </summary>
        public OpKind Op3Kind { get { return (this as IOpCode).Op3Kind; } }
        /// <summary>
        /// The OpKind of Operand 4. This is OpKind.None by default (absence of Operand.)
        /// </summary>
        public OpKind Op4Kind { get { return (this as IOpCode).Op4Kind; } }
        /// <summary>
        /// The OpKind of Operand 5. This is OpKind.None by default (absence of Operand.)
        /// </summary>
        public OpKind Op5Kind { get { return (this as IOpCode).Op5Kind; } }


        public Instruction(params object?[] operands)
        {
            Operands = (operands.Clone() as object?[])!;

            for (int i = 0; i < OpCount; i++)
            {
                ref object? operand = ref operands[i];

                if (operand is Register regID)
                {
                    operand = Registrar.Find(regID);
                }
                else
                {
                    operand = new Core.Data.Object(operand);
                }
            }

            NativeOperands = System.Runtime.CompilerServices.Unsafe.As<Core.Data.Register[]>(operands);
        }

        public Instruction Decorate(Decor decor)
        {
            Decor |= decor;
            return this;
        }

        public Instruction Undecorate(Decor decor)
        {
            Decor &= ~decor;
            return this;
        }

        public static Instruction operator |(Instruction instruction, Decor decor)
        {
            instruction.Decor |= decor;
            return instruction;
        }

        public static Instruction operator &(Instruction instruction, Decor decor)
        {
            instruction.Decor &= decor;
            return instruction;
        }

        public static Instruction operator ^(Instruction instruction, Decor decor)
        {
            instruction.Decor ^= decor;
            return instruction;
        }

        public static bool operator >(Instruction instruction, Instruction decor)
        {
            return false;
        }

        public static bool operator <(Instruction instruction, Instruction decor)
        {
            return true;
        }
    }
}
