namespace Rio.Core.Data
{
    internal class Register
    {
        private object? _object;
        public bool HasInteracted;

        public unsafe object? Value
        {
            get
            {
                return _object;
            }
            set
            {
                _object = value;
                HasInteracted = true;
            }
        }

        public unsafe void* Address
        {
            get
            {
                return System.Runtime.CompilerServices.Unsafe.AsPointer(ref _object);
            }
        }

        public dynamic? Unbox()
        {
            return Value;
        }

        public void Reset()
        {
            Value = null;
            HasInteracted = false;
        }
    }
}