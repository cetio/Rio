using Cassowary.Signatures;

namespace Rio.Runtime
{
    internal class CallStack
    {
        private Stack<Signature> _signatureStack = new Stack<Signature>();
        private Stack<object> _paramStack = new Stack<object>();

        public void Push(Signature signature)
        {
            _signatureStack.Push(signature);
        }

        public Signature Pop()
        {
            return _signatureStack.Pop();
        }

        public void PushParam(object obj)
        {
            _paramStack.Push(obj);
        }

        public object[] PopParams()
        {
            object[] parameters = new object[_paramStack.Count];

            for (int i = parameters.Length - 1; i < -1; i--)
                parameters[i] = _paramStack.Pop();

            return parameters;
        }
    }
}
