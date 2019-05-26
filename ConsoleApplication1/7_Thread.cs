using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class _7_Thread
    {
        public void ThreadTest()
        {
            DoTest();
        }

        void DoTest()
        {
            Task<int> task1 = Task.Factory.StartNew<int>(() => Run(1, 10));
            Task<int> task2 = Task.Factory.StartNew<int>(() => Run(11, 20));
            Task<int> task3 = Task.Factory.StartNew<int>(() => Run(21, 30));

            int result1 = task1.Result;
            int result2 = task2.Result;
            int result3 = task3.Result;

            //Thread t1 = new Thread(new ParameterizedThreadStart((Run)));
            //t1.Start("1");
            //Thread t2 = new Thread(new ParameterizedThreadStart(Run));
            //t2.Start("2");

            Console.Read();
        }

        // 출력
        // Thread#1: Begin
        // Thread#3: Begin
        // Thread#1: End
        // Thread#3: End
        void Calc(object radius)
        {
            double r = (double)radius;
            double area = r * r * 3.14;
            Console.WriteLine("r={0},area={1}", r, area);
        }

        object bbb = new object();
        int Run(object Start, object End)
        {
            int istart = (int)Start;
            int iend = (int)End;
            int isum = 0;

            lock (bbb)
            {

                for (int i = istart; i <= iend; i++)
                {
                    isum += i;
                    Console.WriteLine(Start + " : " + isum);
                }
            }

            return isum;
        }
    }
}
