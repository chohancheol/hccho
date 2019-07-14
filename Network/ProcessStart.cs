using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    class ProcessStart
    {
        public void ProcessRun()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"caculate.exe";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;
            start.Arguments = "1 2 3 4 5 6 7 8 9 10";

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}
