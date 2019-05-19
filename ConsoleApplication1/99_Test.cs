using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class _99_Test
    {
        public void Test_99()
        {
        }



        public void Test_01()
        {

        }



        // N*N 배열 대각선으로 순번 처리
        public void Test_07()
        {
            string[,] iArray = new string[10, 10];
            int iPos = 0;

            int yPos = 0;
            int iCount = 0;

            while (true)
            {
                int xPos = 0;
                for (int i = iPos; i >= 0; i--)
                {
                    iCount++;
                    xPos = xPos + 1;
                    yPos = i + 1;
                    Console.WriteLine(xPos + "/" + yPos);
                }

                iPos++;

                if (iCount >= 14)
                    break;
            }
        }


        //입력 문자열 Reverse
        public void Test_06()
        {
            string inputStr = Console.ReadLine();

            string[] values = inputStr.Split(' ');

            List<int> iList = new List<int>();

            foreach(string val in values)
            {
                char[] cdata = val.ToArray();

                Array.Reverse(cdata);

                string outString = new string(cdata);
                Console.WriteLine(outString);
            }

            Console.ReadLine();
        }

        /* 숫자 곱하기의 숫자 갯수 */
        public void Test_05()
        {
            int a;
            int b;
            int c;

            string inputStr = Console.ReadLine();

            string[] values = inputStr.Split(' ');

            int sum = 1;
            foreach (string aa in values)
            {
                sum = sum * int.Parse(aa);
            }

            string sumString = sum.ToString();

            int[] iCount = new int[10];

            for(int i=0; i < 10; i++)
            {
                iCount[i] = 0;
            }

            foreach(char cchar in sumString)
            {
                int i = int.Parse(cchar.ToString());
                iCount[i] += 1;
            }


            for (int i = 0; i < 10; i++)
            {
                if (iCount[i] != 0)
                 Console.WriteLine(i.ToString() + " : " + iCount[i]);
            }

            Console.Read();
        }

        // Dictionary를 이용한 가장 자주 사용되는 문자열 세기
        public void Test_04()
        {
            Dictionary<string, int> d1 = new Dictionary<string, int>();

            string inputStr = Console.ReadLine();

            foreach(char c in inputStr)
            {
                string sindex = c.ToString();
                if (d1.ContainsKey(sindex))
                    d1[sindex] = d1[sindex] + 1;
                else
                    d1.Add(sindex, 1);
            }

            var maxValue = d1.Values.Max();

            var maxLists = d1.Where(x => x.Value.Equals(maxValue)).ToList();

            if (maxLists.Count() > 1)
                Console.WriteLine("?");
            else
                Console.WriteLine(maxLists[0].Key);

        }

        //입력을 받아 알파벳 배열에 index 넣기
        public void Test_03()
        {
            int[] result = new int[26];
            string inputStr = Console.ReadLine();
            char[] inputc = inputStr.ToCharArray();

            int iindex = 0;
            foreach (int i in result)
            {
                result[iindex] = -1;
                iindex++;
            }

            iindex = 0;
            foreach(char c in inputc)
            {
                int i = c - 97;
                if (result[i] == -1) result[i] = iindex;
                iindex++;
            }

            foreach (int i in result)
            {
                Console.Write(i.ToString() + ",");
            }

        }

        //Regex Sample
        public void Test_02()
        {
            // Ex1
            string str1 = "강남빌라 역삼아파트 서초APT";
            Regex regex1 = new Regex(@"(아파트|APT)");
            MatchCollection mc1 = regex1.Matches(str1);
            foreach (Match m in mc1)
            {
                // (Captured) Group은 1부터
                Group g = m.Groups[1];
                Console.WriteLine("{0}:{1}", g.Index, g.Value);
            }

            // Ex2
            string str2 = "<ul><li>홈페이지</li><li>주문메뉴</li></ul>";
            Regex regex2 = new Regex(@"<li>(\w+)</li>");
            MatchCollection mc2 = regex2.Matches(str2);
            foreach (Match m in mc2)
            {
                Group g = m.Groups[1];
                Console.WriteLine("{0}:{1}", g.Index, g.Value);
            }

            // Ex3
            string str3 = "02-632-5432; 032-645-7361";
            Regex regex3 = new Regex(@"(\d+)-(\d+-\d+)");
            MatchCollection mc3 = regex3.Matches(str3);
            foreach (Match m in mc3)
            {
                for (int i = 1; i < m.Groups.Count; i++)
                {
                    Group g = m.Groups[i];
                    Console.WriteLine("{0}:{1}", g.Index, g.Value);
                }
            }
        }
    }
}
