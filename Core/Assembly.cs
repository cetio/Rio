using Cassowary;
using System.Runtime.InteropServices;

namespace Rio.Core
{
    internal class Assembly
    {
        [DllImport("kernel32.dll")]
        internal static extern nint VirtualAlloc(nint lpStartAddr, int size, uint flAllocationType, uint flProtect);

        private static List<byte> _bytes = new List<byte>();

        public static void Add(byte[] bytes)
        {
            _bytes.AddRange(bytes);
        }

        public static nint? Execute(object?[] parameters, Type[] parameterTypes)
        {
            byte[] pinnedBytes = GC.AllocateArray<byte>(_bytes.Count, true);
            Marshal.Copy(Marshal.UnsafeAddrOfPinnedArrayElement(_bytes.ToArray(), 0), pinnedBytes, 0, _bytes.Count);
            nint address = Marshal.UnsafeAddrOfPinnedArrayElement(pinnedBytes, 0);

            // Make the bytes a RWX section
            VirtualAlloc(address, pinnedBytes.Length, 0x1000, 0x40);

            // Execute the shellcode and return the result
            return Reflection.FastInvoke(
                Marshal.GetDelegateForFunctionPointer(address, Reflection.CreateDelegate(typeof(nint), parameterTypes)
                ), parameters) as nint?;
        }
    }
}