using System;
using System.Runtime.InteropServices;

namespace GIP.Common
{
    public static class CMethods
    {
        private const string DllName_Kernel32 = "kernel32.dll";

        [DllImport(DllName_Kernel32, EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr inDst, IntPtr inSrc, uint inCount);
    }
}
