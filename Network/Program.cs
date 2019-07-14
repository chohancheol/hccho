using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    class Program
    {
        static void Main(string[] args)
        {

            FileSample file = new FileSample();
            file.FileProcss();

            file.GetDir();

            ProcessStart process = new ProcessStart();
            process.ProcessRun();
            //Console.Read();

            ThreadTest th = new ThreadTest();
            th.ThStart();

            Scheduler sch = new Network.Scheduler();
            sch.SchedulerStart();

            Console.Read();
        }
    }
}
