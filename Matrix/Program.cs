using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            ArrayRotate.printArray(arr);
            ArrayRotate.leftRotate(arr, 2);
            ArrayRotate.printArray(arr);
            ArrayRotate.rightRotate(arr, 2);
            ArrayRotate.printArray(arr);



            int N = 4;

            // Test Case 1 
            int[,] mat =
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16}
            };

            ArrayRotate.displayMatrix(N, mat);
            
            ArrayRotate.rotateLeftMatrix(N, mat);

            ArrayRotate.displayMatrix(N, mat);

            ArrayRotate.rotateRightMatrix(N, mat);

            ArrayRotate.displayMatrix(N, mat);

            ArrayRotate.reverseMatirx(mat);

            ArrayRotate.displayMatrix(N, mat);

            int[,] mat2 =
{
                {1, 2, 3, 4, 5},
                {5, 6, 7, 8, 9},
                {9, 10, 11, 12, 13},
                {13, 14, 15, 16, 17}
            };

            int[,] mat3 = ArrayRotate.RotateLeftMatrix(mat2);
            int[,] mat4 = ArrayRotate.RotateRightMatrix(mat3);

            ArrayRotate.displayMatrix2(mat2);
            ArrayRotate.displayMatrix2(mat3);
            ArrayRotate.displayMatrix2(mat4);

            ArrayRotate.shiftRightMatrix(mat4, 3);

            ArrayRotate.displayMatrix2(mat4);

            ArrayRotate.shiftLeftMatrix(mat4, 2);

            ArrayRotate.displayMatrix2(mat4);

            var mat5 = ArrayRotate.RotateLeft(mat4);

            ArrayRotate.displayMatrix2(mat5);

            var mat6 = ArrayRotate.RotateRight(mat5);

            ArrayRotate.displayMatrix2(mat6);

            //KeyGenerate.KeyGen();

            //KeyGenerate.GetDirectorySize(@"c:\hccho");

            Console.ReadKey();

        }

        public static MatchCollection CreateMatchCollection(string source, string target, bool matchWholeWord, bool matchCase)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (matchWholeWord)
            {
                stringBuilder.Append(@"(?<=\W{0,1})");
                stringBuilder.Append(target);
                stringBuilder.Append(@"(?=\W)");
            }

            if (matchCase)
            {
                stringBuilder.Insert(0, "(?i)");
            }

            return Regex.Matches(source, stringBuilder.ToString());
        }
    }
}
