using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class _85_Combination
    {
        public void Test()
        {
            int[] tempArray = { 1, 2, 3, 4 };
            //StringBuilder sb = new StringBuilder();
            //StringCombination("ABC", sb, 0);

            //Combination ex = new Combination();
            int[] arr = { 1, 3, 5, 7 };
            int n = arr.Length;
            int r = 4;
            int[] combArr = new int[n];

            perm(arr, 0);   // ex) 3개의 조합 전체
            //doCombination(combArr, n, r, 0, 0, arr);    //전체 N개중 C개 조합 (동일 데이터 없음)
            //doCombination2(combArr, arr, n, r, 0, 0);   //전체 N개중 C개 조합 (순서가 다르면 다름)

            //int[] arr = { 1, 2, 3 };


            caseString.Sort();
            Console.Read();

        }

        List<string> caseString = new List<string>();
        public void perm(int[] arr, int pivot)
        {
            if (pivot == arr.Length)
            {
                print(arr); return;
            }
            for (int i = pivot; i < arr.Length; i++)
            {
                swap(arr, i, pivot);
                perm(arr, pivot + 1);
                swap(arr, i, pivot);
            }
        }

        public void print(int[] arr)
        {
            string sString = string.Empty;
            foreach (int item in arr)
            {
                sString = sString + "," + item;
                //Console.WriteLine(arr[combArr[i]] + " ");
            }
            sString = sString.Trim(',');
            caseString.Add(sString);
        }



        //경우의 수 조합 ex) 5개중 3개 선택, 순서상관있음 --> 1,2,3  1,2,4 1,2,5 1,3,4 1,3,5.....
        // 1,2,3   1,3,2 는 다름
        //int[] arr = { 1, 3, 5, 7, 9 };
        //int n = arr.Length;
        //int r = 3;
        //int[] combArr = new int[n];
        //doCombination2(combArr, arr, n, r, 0, 0);
        public void doCombination2(int[] combArr, int[] arr, int n, int r, int index, int target)
        {
            if (r == 0)
            {
                //to-do: combArr permutation
                doPermutation(combArr, 0);
            }
            else if (target == n) return;
            else
            {
                combArr[index] = arr[target];
                doCombination2(combArr, arr, n, r - 1, index + 1, target + 1);
                doCombination2(combArr, arr, n, r, index, target + 1);
            }
        }

        public void doPermutation(int[] arr, int startIdx)
        {
            int length = arr.Length;
            if (startIdx == length - 1)
            {
                string sString = string.Empty;
                foreach (int item in arr)
                {
                    sString = sString + "," + item;
                    //Console.WriteLine(arr[combArr[i]] + " ");
                }
                sString = sString.Trim(',');
                caseString.Add(sString);

                return;
            }
            for (int i = startIdx; i < length - 1; i++)
            {
                swap(arr, startIdx, i);
                doPermutation(arr, startIdx + 1);
                swap(arr, startIdx, i);
            }
        }

        public void swap(int[] arr, int n1, int n2)
        {
            int temp = arr[n1];
            arr[n1] = arr[n2];
            arr[n2] = temp;
        }


        //경우의 수 조합 ex) 5개중 3개 선택, 순서상관없이 --> 1,2,3  1,2,4 1,2,5 1,3,4 1,3,5.....
        //// 1,2,3   1,3,2 는 동일
        //int[] arr = { 1, 3, 5, 7, 9 };
        //int n = arr.Length;
        //int r = 3;
        //int[] combArr = new int[n];
        //doCombination(combArr, n, r, 0, 0, arr);
        public void doCombination(int[] combArr, int n, int r, int index, int target, int[] arr)
        {
            if (r == 0)
            {
                string sString = string.Empty;
                for (int i = 0; i < index; i++)
                {
                    sString = sString + "," + arr[combArr[i]];
                    //Console.WriteLine(arr[combArr[i]] + " ");
                }
                sString = sString.Trim(',');
                caseString.Add(sString);

            }
            else if (target == n) return;
            else
            {
                combArr[index] = target;
                doCombination(combArr, n, r - 1, index + 1, target + 1, arr); // (i)
                doCombination(combArr, n, r, index, target + 1, arr); //(ii)
            }
        }


        //순서 모든 조합  
        //StringBuilder sb = new StringBuilder();
        //StringCombination("ABC", sb, 0); --> A, B, C, AB, AC, BC, ABC
        void StringCombination(string s, StringBuilder sb, int index)
        {
            for (int i = index; i < s.Length; i++)
            {
                // 1) 한 문자 추가
                sb.Append(s[i]);

                // 2) 구한 문자조합 출력
                caseString.Add(sb.ToString());
                //Console.WriteLine(sb.ToString());

                // 3) 나머지 문자들에 대한 조합 구하기
                StringCombination(s, sb, i + 1);

                // 위의 1에서 추가한 문자 삭제 
                sb.Remove(sb.Length - 1, 1);
            }
        }


        //배열을 좌측으로 회전
        public T[,] RotateLeft<T>(T[,] sourceArray)

        {

            //int[,] iArrayLeft = RotateLeft(iArray) 사용;
            int lengthY = sourceArray.GetLength(0);
            int lengthX = sourceArray.GetLength(1);

            T[,] targetArray = new T[lengthX, lengthY];

            for (int y = 0; y < lengthY; y++)
            {
                for (int x = 0; x < lengthX; x++)
                {
                    targetArray[x, y] = sourceArray[y, lengthX - 1 - x];
                }
            }

            return targetArray;
        }
    }
}
