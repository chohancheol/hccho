using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class _82_mergeToArray
    {
        //두개의 배열을 1개의 배열로 Merge
        public static int[] merge(int[] arr1, int[] arr2)
        {

            int[] arr = new int[arr1.Length + arr2.Length];
            int len = arr1.Length > arr2.Length ? arr2.Length : arr1.Length;
            int i = 0, j = 0, k = 0, z = 0;

            /*   Array Sorting 사용
            int index = 0;
            foreach(int a in arr1)
            {
                arr[index] = arr1[index];
                index++;
            }
            int jndex = 0;
            foreach (int a in arr2)
            {
                arr[index] = arr2[jndex];
                jndex++;
                index++;
            }

            Array.Sort(arr);
            //arr.OrderBy(n => n);
            return arr;
            */
            while (z < len)
            {
                while (arr1[i] <= arr2[j])
                {
                    arr[k] = arr1[i];
                    i++;
                    k++;
                    z++;
                }
                while (arr2[j] <= arr1[i])
                {
                    arr[k] = arr2[j];
                    j++;
                    k++;
                    z++;
                }

            }

            if (i < arr1.Length)
            {
                while (i < arr1.Length)
                {
                    arr[k] = arr1[i];
                    i++;
                    k++;
                }
            }
            if (j < arr2.Length)
            {
                while (j < arr2.Length)
                {
                    arr[k] = arr2[j];
                    j++;
                    k++;

                }
            }

            for (int f = 0; f < arr.Length; f++)
            {
                Console.WriteLine(arr[f] + " ");
            }

            return arr;
        }
    }
}
