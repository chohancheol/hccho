using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class ArrayRotate
    {
        public static void leftRotate(int[] arr, int d )
        {
            int n = arr.Length;
            for (int i = 0; i < d; i++)
                leftRotatebyOne(arr);
        }

        public static void leftRotatebyOne(int[] arr)
        {
            int n = arr.Length;
            int i, temp = arr[0];
            for (i = 0; i < n - 1; i++)
                arr[i] = arr[i + 1];

            arr[i] = temp;
        }

        public static void rightRotate(int[] arr, int d)
        {
            int n = arr.Length;
            for (int i = 0; i < d; i++)
                rightRotatebyOne(arr);
        }

        public static void rightRotatebyOne(int[] arr)
        {
            int n = arr.Length;
            int i, temp = arr[n-1];
            for (i = n- 1; i > 0; i--)
                arr[i] = arr[i - 1];

            arr[0] = temp;
        }

        /* utility function to print an array */
        public static void printArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }

        
        public static void rotateLeftMatrix(int N, int[,] mat)
        {
            // Consider all  
            for (int x = 0; x < N / 2; x++)
            {

                for (int y = x; y < N - x - 1; y++)
                {
                    int temp = mat[x, y];

                    mat[x, y] = mat[y, N - 1 - x];

                    mat[y, N - 1 - x] = mat[N - 1 - x,
                                            N - 1 - y];
                    mat[N - 1 - x,
                        N - 1 - y] = mat[N - 1 - y, x];
                    mat[N - 1 - y, x] = temp;
                }
            }
        }

        public static void rotateRightMatrix(int N, int[,] mat)
        {
            for (int i = 0; i < N / 2; i++)
            {
                for (int j = i; j < N - i - 1; j++)
                {

                    // Swap elements of each cycle 
                    // in clockwise direction 
                    int temp = mat[i, j];
                    mat[i, j] = mat[N - 1 - j, i];
                    mat[N - 1 - j, i] = mat[N - 1 - i, N - 1 - j];
                    mat[N - 1 - i, N - 1 - j] = mat[j, N - 1 - i];
                    mat[j, N - 1 - i] = temp;
                }
            }
        }

        // Function to print the matrix 
        public static void displayMatrix(int N, int[,] mat)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(" " + mat[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 우측과 좌측을 변경
        /// </summary>
        /// <param name="matrix"></param>
        public static void reverseMatirx(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int begin = 0, end = matrix.GetLength(0) - 1;
                while (begin < end)
                {
                    int temp = matrix[i, begin];
                    matrix[i, begin] = matrix[i, end];
                    matrix[i, end] = temp;
                    begin++;
                    end--;
                }
            }
        }


        /// <summary>
        /// 우측으로 Shift
        /// </summary>
        /// <param name="matrix"></param>
        public static void shiftRightMatrix(int[,] mat, int k)
        {
            int M = mat.GetLength(1);
            int N = mat.GetLength(0);


            int[] temp = new int[M];

            k = k % M;

            for (int i = 0; i < N; i++)
            {
                for (int t = 0; t < M - k; t++)
                    temp[t] = mat[i, t];

                for (int j = M - k; j < M; j++)
                    mat[i, j - M + k] = mat[i, j];

                for (int j = k; j < M; j++)
                    mat[i, j] = temp[j - k];
            }

        }

        /// <summary>
        /// 우측으로 Shift
        /// </summary>
        /// <param name="matrix"></param>
        public static void shiftLeftMatrix(int[,] mat, int k)
        {
            int M = mat.GetLength(1);
            int N = mat.GetLength(0);

            int[] temp = new int[M];

            k = k % M;

            for (int i = 0; i < N; i++)
            {

                for (int t = 0; t < k; t++)
                    temp[t] = mat[i, t];

                for (int j = k; j < M; j++)
                    mat[i, j - k] = mat[i, j];

                for (int j = M - k; j < M; j++)
                    mat[i, j] = temp[j - M + k];
            }

        }

        public static int[,] RotateLeftMatrix(int[,] oldMatrix)
        {
            int[,] newMatrix = new int[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }

        public static int[,] RotateRightMatrix(int[,] oldMatrix)
        {
            int[,] newMatrix = new int[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = 0; oldColumn < oldMatrix.GetLength(1); oldColumn++)
            {
                newColumn = 0;
                for (int oldRow = oldMatrix.GetLength(0)- 1; oldRow >= 0; oldRow--)
                {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }


        public static T[,] RotateLeft<T>(T[,] sourceArray)
        {
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

        public static T[,] RotateRight<T>(T[,] sourceArray)
        {
            int lengthY = sourceArray.GetLength(0);
            int lengthX = sourceArray.GetLength(1);

            T[,] targetArray = new T[lengthX, lengthY];

            for (int y = 0; y < lengthY; y++)
            {
                for (int x = 0; x < lengthX; x++)
                {
                    targetArray[x, y] = sourceArray[lengthY - 1 - y, x];
                }
            }

            return targetArray;
        }

        public static void displayMatrix2(int[,] mat)
        {
            int N = mat.GetLength(0);
            int M = mat.GetLength(1);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                    Console.Write(" " + mat[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
