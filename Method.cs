using Rio.Core;
using Rio.Emit;

namespace Rio
{
    public class Method
    {
        public Instruction[] Instructions { get; private set; }
        public Type[] Parameters { get; private set; }

        public int Token
        {
            get
            {
                return GetHashCode();
            }
        }

        public Method(Type[] parameters, Instruction[] instructions)
        {
            Instructions = instructions;
            Parameters = parameters;
        }

        public object? Invoke(params object?[] parameters)
        {
            if (parameters.Length > Parameters.Length)
                throw new Exception("Provided parameters length exceeds delegate parameters length!");

            return Engine.Invoke(Instructions, parameters);
        }
    }
}