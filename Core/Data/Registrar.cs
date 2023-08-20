namespace Rio.Core.Data
{
    internal static class Registrar
    {
        private static Register[] _registers;

        static Registrar()
        {
            _registers = new Register[Enum.GetValues<Emit.Register>().Length];

            for (int i = 0; i < 38; i++)
                _registers[i] = new Register();
        }

        public static Register Find(Emit.Register regID)
        {
            return _registers[(int)regID];
        }

        public static Register Current()
        {
            return _registers.Where(x => x.HasInteracted).LastOrDefault() ?? _registers.Last();
        }

        public static Register Next()
        {
            return _registers.Where(x => !x.HasInteracted).FirstOrDefault() ?? _registers.Last();
        }

        public static Register[] PersonalRegisters()
        {
            return _registers.Where(x => x.HasInteracted &&
                Array.IndexOf(_registers, x) >= (int)Emit.Register.RP0 &&
                Array.IndexOf(_registers, x) <= (int)Emit.Register.RP23).ToArray();
        }

        public static Register[] CallRegisters()
        {
            return _registers.Where(x => x.HasInteracted &&
                Array.IndexOf(_registers, x) >= (int)Emit.Register.CR0 &&
                Array.IndexOf(_registers, x) <= (int)Emit.Register.CR11).ToArray();
        }

        public static void Reset(Emit.Register regID)
        {
            _registers[(int)regID].Reset();
        }

        public static void Reset()
        {
            for (int i = 0; i < 38; i++)
                _registers[i] = new Register();
        }
    }
}
