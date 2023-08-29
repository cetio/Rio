using System.Runtime.InteropServices;

namespace Rio.Runtime.TSO
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct TSOFrame
    {
        public bool HasPrepared;

        public bool HasVisited;

        public int TotalBlockSize;

        public int NumVariants;

        public int NumInstructions;

        public byte[] Data;
    }
}
