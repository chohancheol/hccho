using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Network
{
    class ThreadTest
    {
        public void ThStart()
        {
            Thread t1 = new Thread(new ThreadStart(Run));
            t1.Start();

            // ParameterizedThreadStart 파라미터 전달
            // Start()의 파라미터로 radius 전달
            Thread t2 = new Thread(new ParameterizedThreadStart(Calc));
            t2.Start(10.00);

            t1.Join();
            t2.Join();  // 종료 대기
            ThreadPool.QueueUserWorkItem(Calc, 20.0);

            // 스레드에서 사용할 파라미터 설정후 Return 값 처리            
            double rValue1 = 0;
            double rValue2 = 0;

            Thread ThreadForWork1 = new Thread(delegate () { rValue1 = Calc1(20.0); });
            ThreadForWork1.Start();

            ThreadForWork1.Join();

            Thread ThreadForWork2 = new Thread(delegate () { rValue2 = Calc1(20.0); });
            ThreadForWork2.Start();

            ThreadForWork2.Join();

            Console.WriteLine(rValue1 + "," + rValue2);

        }

        // radius라는 파라미터를 object 타입으로 받아들임
        static void Calc(object radius)
        {
            double r = (double)radius;
            double area = r * r * 3.14;
            Console.WriteLine("r={0},area={1}", r, area);
        }

        static void Run()
        {
            Console.WriteLine("Run");
        }

        // radius라는 파라미터를 object 타입으로 받아들임
        static double Calc1(object radius)
        {
            double r = (double)radius;
            double area = r * r * 3.14;
            Console.WriteLine("r={0},area={1}", r, area);

            return area;
        }
    }
}
