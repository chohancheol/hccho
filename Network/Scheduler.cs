using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Network
{
    class Scheduler
    {
        public void SchedulerStart()
        {
            bool jobIsEnabledA = true;
            bool jobIsEnabledB = true;
            bool jobIsEnabledC = true;

            try
            {

                while (true)
                {
                    var currentTime = DateTime.Now.ToString("h:mm");

                    if (currentTime == "3:15")
                    {
                        jobIsEnabledA = false;
                        ThreadPool.QueueUserWorkItem((state) => { Console.WriteLine(string.Format("Time to brush your teeth! {0}", currentTime)); });
                    }

                    if (currentTime == "3:20")
                    {
                        jobIsEnabledB = false;
                        ThreadPool.QueueUserWorkItem((state) => { Console.WriteLine(string.Format("Time to brush your teeth! {0}", currentTime)); });
                    }

                    if (currentTime == "3:30")
                    {
                        ThreadPool.QueueUserWorkItem((state) => { Console.WriteLine(string.Format("Time for your favorite show! {0}", currentTime)); });
                    }

                    if (currentTime == "3:31")
                    {
                        jobIsEnabledA = true;
                        jobIsEnabledB = true;
                        jobIsEnabledC = true;
                    }

                    var logText = string.Format("{0} jobIsEnabledA: {1} jobIsEnabledB: {2} jobIsEnabledC: {3}", DateTime.Now.ToString("h:mm:ss"), jobIsEnabledA, jobIsEnabledB, jobIsEnabledC);

                    using (StreamWriter writer = File.AppendText("scheduler_log.txt"))
                    {
                        writer.WriteLine(logText);
                    }

                    Thread.Sleep(1000);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
