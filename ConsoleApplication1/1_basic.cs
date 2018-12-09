using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class _1_basic
    {
        enum City
        {
            Seoul,   // 0
            Daejun,  // 1
            Busan = 5,  // 5
            Jeju = 10   // 10
        }

        public void Variable()
        {
            City myCity;

            // enum 타입에 값을 대입하는 방법
            myCity = City.Seoul;

            // enum을 int로 변환(Casting)하는 방법. 
            // (int)를 앞에 지정.
            int cityValue = (int)myCity;

            if (myCity == City.Seoul) // enum 값을 비교하는 방법
            {
                Console.WriteLine("Welcome to Seoul");
            }

            string category = "사과";
            double price = 0;

            switch (category)
            {
                case "사과":
                    price = 1000;
                    break;
                case "딸기":
                    price = 1100;
                    break;
                case "포도":
                    price = 900;
                    break;
                default:
                    price = 0;
                    break;
            }

            Console.WriteLine("Price : " + price);

            // for문
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Loop {0}", i);
            }

            // foreach문
            string[] array = new string[] { "AB", "CD", "EF" };
            foreach (string s in array)
            {
                Console.WriteLine("foreach : " + s);
            }

            //while문
            int i2 = 1;
            while (i2 <= 10)
            {
                Console.WriteLine("while : " + i2);
                i2++;
            }

            //do while문
            List<char> keyList = new List<char>();
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
                keyList.Add(key.KeyChar);
            } while (key.Key != ConsoleKey.Q); // Q가 아니면 계속

            foreach (char ch in keyList) // 리스트 루프
            {
                Console.WriteLine("do while : " + ch);
            }

        
            //Console.Read();
        }

        public void Array()
        {
            // 1차 배열
            string[] players = new string[10];
            string[] Regions = { "서울", "경기", "부산" };

            // 2차 배열 선언 및 초기화
            string[,] Depts = { { "김과장", "경리부" }, { "이과장", "총무부" } };

            // 3차 배열 선언
            string[,,] Cubes;

            for (int i = 0; i < Depts.GetLength(0); i++)
            {
                for (int j = 0; j < Depts.GetLength(1); j++)
                {
                    Console.WriteLine("Dept : " + Depts[i,j]);
                }
            }


            int[][] jaggedArray = { new int[] {1,2,3,4},
                                new int[] {5,6,7},
                                new int[] {8},
                                new int[] {9}
                              };

            int[,] multiDimArray = {{1,2,3,4},
                                 {5,6,7,0},
                                 {8,0,0,0},
                                 {9,0,0,0}
                                };


            for(int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.WriteLine("jaggedArray : " + jaggedArray[i][j]);
                }
            }

            // 3차배열 선언
            string[,,] arr = new string[,,] {
                { {"1", "2"}, {"11","22"} },
                { {"3", "4"}, {"33", "44"} }
            };

            //foreach 루프 : 한번에 3차배열 모두 처리
            foreach (var s in arr)
            {
                Console.WriteLine("3차원 배열 : " + s);
            }


            //Console.Read();
        }


        static IEnumerable<int> GetNumber()
        {
            yield return 10;  // 첫번째 루프에서 리턴되는 값
            yield return 20;  // 두번째 루프에서 리턴되는 값
            yield return 30;  // 세번째 루프에서 리턴되는 값
        }

        public void yield()
        {
            foreach (int num in GetNumber())
            {
                Console.WriteLine(num);
            }

            //Console.Read();
        }
    }
}
