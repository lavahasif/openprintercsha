using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace openprinter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
             // byte[] buffer = new byte[5]
             // {
             //     (byte) 27,
             //     (byte) 112,
             //     (byte) 0,
             //     (byte) 25,
             //     (byte) 250
             // };
//             Console.Write(buffer);
//             string author = "Mahesh Chand";
// // Convert a C# string to a byte array  
//             byte[] bytes = Encoding.ASCII.GetBytes(author);
//             foreach (byte b in bytes)
//             {
//                 Console.WriteLine(b);
//             }
//
//             // SendBytesToLocalPrinter(buffer, "test");
//             // Thread.Sleep(2000);
            const string ESC = "\u001B";
            const string p = "\u0070";
            const string m = "\u0000";
            const string t1 = "\u0025";
            const string t2 = "\u0250";
            const string openTillCommand = ESC + p + m + t1 + t2;

            RawPrinterHelper.SendStringToPrinter("Bill", openTillCommand);
        }

        public static void SendBytesToLocalPrinter(byte[] data, string printerName)
        {
            var size = Marshal.SizeOf(data[0]) * data.Length;
            var pBytes = Marshal.AllocHGlobal(size);
            try
            {
                RawPrinterHelper.SendBytesToPrinter(printerName, pBytes, size);
            }
            finally
            {
                Marshal.FreeCoTaskMem(pBytes);
            }
        }
    }
}