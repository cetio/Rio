using Rio.Emit;
using System.Collections.Immutable;

namespace Rio
{
    public class Function
    {
        public List<Instruction> Instructions { get; internal set; }
        internal Type[] _parameterTypes;
        
        public int Token
        {
            get
            {
                return GetHashCode();
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
            Instructions = instructions ?? new List<Instruction>();
            _parameterTypes = parameterTypes ?? new Type[0];
        }

        public void Assemble(OpCode opcode, params object?[] operands)
        {
            Instructions.Add(new Instruction(opcode, operands));
        }
    }
}
