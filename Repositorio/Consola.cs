using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Repositorio
{
    class Consola
    {
        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int AllocConsole();
        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int FreeConsole();
        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int CloseHandle(int hObject);
        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int GetStdHandle(int nStdHandle);

        public int InvocarConsola()
        {
            return AllocConsole();
        }
    }
}
