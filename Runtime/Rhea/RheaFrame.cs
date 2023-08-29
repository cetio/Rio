using System.Runtime.InteropServices;

namespace Rio.Runtime.Rhea
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct RheaFrame
    {
        public bool HasPrepared;

        public bool HasVisited;

        public int TotalBlockSize;

        public int NumVariants;

        public int NumInstructions;

        public byte[] Data;
    }
}
