using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // basic 문법
            _1_basic Test1 = new _1_basic();

            //Test1.Variable();
            //Test1.Array();

            //Test1.yield();



            // class
            //_2_class Test2 = new _2_class();

            //Test2.reference();

            _8_sample Test8 = new ConsoleApplication1._8_sample();

            int square = Test8.findLargestSquare();


            MyCustomer mc = new ConsoleApplication1.MyCustomer();

            Console.WriteLine(mc.GetCustomerData());

            Console.Read();
        }
    }
}
