using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    class Array
    {
        public static void ArrayMain()
        {
            int[][] Adjustable = new int[3][];

            Adjustable[0] = new int[] { 1, 2, 3, 1, 1 };
            Adjustable[1] = new int[] { 6, 7, 8, 2, 2 };
            Adjustable[2] = new int[] { 9, 10, 11, 3, 3 };

            PrintArray(Adjustable);

            Addsum1(Adjustable);

            Addsum2(Adjustable);

            Console.Read();
        }

        public static void Addsum1(int[][] Adjustable)
        {
            int[][] result = new int[Adjustable.GetLength(0)][];
            for (int i = 0; i < Adjustable.GetLength(0); i++)
            {
                result[i] = new int[Adjustable[i].GetLength(0) + 1];
            }

            for (int i = 0; i < Adjustable.GetLength(0); i++)
            {
                int isum = 0;
                for (int j = 0; j < Adjustable[i].GetLength(0); j++)
                {
                    result[i][j] = Adjustable[i][j];
                    isum += Adjustable[i][j];
                }

                result[i][Adjustable[i].GetLength(0)] = isum;
            }

            PrintArray(result);
        }

        public static void Addsum2(int[][] Adjustable)
        {
            int[][] result = new int[Adjustable.GetLength(0)+1][];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                result[i] = new int[Adjustable[0].GetLength(0)];
            }

            int[] tmpArray = new int[Adjustable[0].GetLength(0)];

            for (int i = 0; i < Adjustable.GetLength(0); i++)
            {
                for (int j = 0; j < Adjustable[i].GetLength(0); j++)
                {
                    result[i][j] = Adjustable[i][j];
                    tmpArray[j] += Adjustable[i][j];
                }
            }

            for (int i = 0; i < result[0].GetLength(0); i++)
            {
                result[Adjustable.GetLength(0)][i] = tmpArray[i];
            }

            PrintArray(result);

            for (int i = 0; i < result[0].GetLength(0) / 2; i++)
            {
                if (result[0].GetLength(0) % 2 == 0 )
                    ChangeArray(result, i, i + result[0].GetLength(0) / 2) ;
                else
                    ChangeArray(result, i, i + result[0].GetLength(0) / 2+1);
            }

            PrintArray(result);
        }

        public static void ChangeArray(int[][] iarray, int i1, int i2)
        {
            for (int i = 0; i < iarray.GetLength(0); i++)
            {
                int tmpValue = iarray[i][i1];
                iarray[i][i1] = iarray[i][i2];
                iarray[i][i2] = tmpValue;
            }
        }


        public static void PrintArray(int[][] iarray)
        {
            Console.WriteLine("----------------------------");
            for (int i = 0; i < iarray.GetLength(0); i++)
            {
                for (int j = 0; j < iarray[i].GetLength(0); j++)
                {
                    Console.Write(iarray[i][j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}