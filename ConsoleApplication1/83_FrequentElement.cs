using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class _83_FrequentElement
    {
        public int counter(int[] ar)
        {
            int count = 0;

            for (int i = 0; i < ar.Length; i++)
            {

                int tempFreq = ar[i];
                int temCount = 0;

                for (int j = i; j < ar.Length; j++)
                {

                    if (tempFreq == ar[j])
                    {
                        temCount++;
                    }
                }

                if (temCount > count)
                {
                    count = temCount;
                }


            }
            return count;
        }


        public int coun(String s, String key)
        {

            int k = 0;
            int l;

            //String[] ar = s.split("");

            for (int i = 0; i < s.Length - (key.Length - 1); i++)
            {

                int j = i;
                l = key.Length;
                String temp = "";

                //                       while (l > 0) {
                //                temp += ar[j];
                //                j++;
                //                l--;
                //
                //            }

                temp = s.Substring(i, key.Length);

                if (temp.Equals(key))
                {
                    k++;
                }

            }

            return k;
        }
    }
}
