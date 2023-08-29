using Rio.Emit;
using Rio.Runtime.TSO;
using System.Collections.Immutable;
using System.Text;

namespace Rio
{
    public class Function
    {
        internal List<Instruction> _instructions;
        internal Type[] _parameterTypes;
        internal ContextFrame _ctxFrame;
        internal RheaFrame _rhFrame;
        
        public int Token
        {
            get
            {
                return GetHashCode();
            }
        }

        public ImmutableArray<Instruction> Instructions
        {
            get
            {
                return _instructions.ToImmutableArray();
            }
        }

        public ImmutableArray<Type> ParameterTypes
        {
            get
            {
                return _parameterTypes.ToImmutableArray();
            }
        }

        public Function(List<Instruction>? instructions = null, Type[]? parameterTypes = null)
        {
            _instructions = instructions ?? new List<Instruction>();
            _parameterTypes = parameterTypes ?? new Type[0];
            _ctxFrame = new ContextFrame();
            _rhFrame = new RheaFrame();
        }

        public void Assemble(OpCode opcode, params object?[] operands)
        {
            _instructions.Add(new Instruction(opcode, operands));
        }

        public void Officiate()
        {
            RuntimeHelpers.PrepareFrame(_instructions, ref _tsoFrame);
            RuntimeHelpers.PrepareVariants(_instructions, ref _tsoFrame);
        }

        public StringBuilder Scribe()
        {
            return Rio.Scribe.Write(this);
        }
    }
}
