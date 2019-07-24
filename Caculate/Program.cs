using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculate
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double dSum = 0;
                foreach (var item in args)
                {
                    dSum += double.Parse(item);
                }

                Console.WriteLine(dSum.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR");
            }
        }
    }
}
