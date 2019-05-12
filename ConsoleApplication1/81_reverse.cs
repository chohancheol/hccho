using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class _81_reverse
    {
        // Reverse String (맨처음과 끝자리 부터 하나씩 변경)
        public static char[] ReverseString1(String s)
        {

            char[] array;
            array = s.ToCharArray();
            char temp;

            for (int i = 0; i < array.Length / 2; i++)
            {
                int j = array.Length - 1 - i;

                temp = array[i];
                array[i] = array[j];
                array[j] = temp;

            }
            Console.WriteLine(array);

            /* Reverse활용 
            char[] array2;

            array2 = s.ToCharArray();

            array2 = array2.Reverse().ToArray();

            Console.WriteLine(array2);
            */
            return array;
        }

        //Reverse String(문자열 순서를 변경)
        public static char[] ReverseStringinArray(String s)
        {
            char ch = ' ';
            char temp;
            char[] array = ReverseString1(s);
            int count = 0;
            int count1 = 0;

            for (int i = 0; i < array.Length; i++)
            {

                count++;
                if (array[i] == ch)
                {
                    count = count - 1;
                    int k = i - count;
                    count = count / 2;

                    for (int j = i - 1; count > 0; j--)
                    {

                        temp = array[k];
                        array[k] = array[j];
                        array[j] = temp;
                        count--;
                        k++;
                    }
                    count = 0;
                }

            }

            for (int i = array.Length - 1; i > 0; i--)
            {

                if (array[i] == ch)
                {

                    int k = array.Length - 1;
                    count1 = count1 / 2;

                    for (int j = i + 1; count1 > 0; j++)
                    {
                        temp = array[k];
                        array[k] = array[j];
                        array[j] = temp;
                        count1--;
                        k--;
                    }
                    break;

                }
                count1++;


            }



            return array;
        }


        public static String reverse(String s)
        {

            char[] arr = s.ToCharArray();

            char[] fin = new char[arr.Length];



            for (int i = 0; i < arr.Length; i++)
            {
                int j = arr.Length - 1 - i;

                fin[j] = arr[i];
                // j--;

            }

            Console.WriteLine(fin);



            char[] arr2 = new char[fin.Length];
            int count;
            int count1 = 0;
            int count2 = 0;
            char ch = ' ';
            for (int i = 0; i < fin.Length; i++)
            {
                count = i;

                if (fin[i] == ch || i == fin.Length - 1)
                {

                    while (count >= 0 && count >= count2)
                    {

                        arr2[count1++] = fin[count--];

                    }
                    count2 = count1;
                }

            }

            String s1 = new String(arr2);

            return s1;
        }
    }
}
