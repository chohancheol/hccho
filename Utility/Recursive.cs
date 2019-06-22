using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    class Recursive
    {
        //상태공간 트리를 이용한 멱집합 (순서 무관)
        private static char[] data = { 'a', 'b', 'c', 'd' };
        private static int n = data.Length;
        private static bool[] include = new bool[n];

        public static void PowerSet(int k)
        {
            if (k == n)
            {
                for (int i = 0; i < n; i++)
                {
                    if (include[i]) Console.Write(data[i] + " ");
                }
                Console.WriteLine();
                return;
            }

            include[k] = false;
            PowerSet(k + 1);
            include[k] = true;
            PowerSet(k + 1);
        }

        //순열 (순서 상관)
        public static void Permutation(int k)
        {
            if (k == n)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    Console.Write(data[i] + " ");
                }
                Console.WriteLine();
                return;
            }

            for (int i = k; i < n; i++)
            {
                swap(data, k, i);
                Permutation(k + 1);
                swap(data, k, i);
            }
        }

        public static void swap(char[] array, int k, int i)
        {
            char temp;
            temp = array[k];
            array[k] = array[i];
            array[i] = temp;
        }

        //Knapsack(배낭 문제) - 멱집합을 활용
        public static void Knapsack()
        {

        }

        //Traveling Salesperson's problem (모든 도시를 거쳐갈 경우) : 순열을 사용
        public static void TSP()
        {

        }

        public static void PrintInBinary(int k)
        {
            if (k < 2)
                Console.Write(k);
            else
            {
                PrintInBinary(k / 2);
                Console.Write(k % 2);
            }
        }

        public static int BinarySearch(string[] items, string target, int begin, int end)
        {
            if (begin > end || begin < 0 || end > items.Length)
                return -1;
            else
            {
                int imiddle = (begin + end) / 2;
                int comResult = target.CompareTo(items[imiddle]);
                if (comResult == 0)
                    return imiddle;
                else if (comResult < 0)
                    return BinarySearch(items, target, begin, imiddle - 1);
                else
                    return BinarySearch(items, target, imiddle + 1, end);
            }
        }

        private static int N = 8;
        private static int[,] maze = { { 0, 0, 0, 0, 0, 0, 0, 1 },
                                       { 0, 1, 1, 0, 1, 1, 0, 1 },
                                       { 0, 0, 0, 1, 0, 0, 0, 1 },
                                       { 0, 1, 0, 0, 1, 1, 0, 0 },
                                       { 0, 1, 1, 1, 0, 0, 1, 1 },
                                       { 0, 1, 0, 0, 0, 1, 0, 1 },
                                       { 0, 0, 0, 1, 0, 0, 0, 1 },
                                       { 0, 1, 1, 1, 0, 1, 0, 0 } };
        private static int PATHWAY_COLOR = 0;
        private static int WALL_COLOR = 1;
        private static int BLOCKED_COLOR = 2;
        private static int PATH_COLOR = 3;
        public static bool FindMazePath(int x, int y)
        {
            if (x < 0 || y < 0 || x >= N || y >= N)
                return false;
            else if (maze[x, y] != PATHWAY_COLOR)
                return false;
            else if (x == N-1 && y == N-1)
            {
                maze[x,y] = PATH_COLOR;
                return true;
            }
            else
            {
                maze[x, y] = PATH_COLOR;
                if (FindMazePath(x-1, y) || FindMazePath(x, y+1) 
                    || FindMazePath(x+1, y) || FindMazePath(x, y-1))
                {
                    return true;
                }
                maze[x, y] = BLOCKED_COLOR;
                return false;
            }
        }

        public static void printMaze()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();

            }
        }

        static int[] cols = new int[N + 1];
        public static bool queens(int level)
        {
            if (!promising(level))
                return false;
            else if (level==N)
            {
                for (int i = 1; i <= N ; i++)
                {
                    Console.WriteLine("(" + i + ", " + cols[i] + ")");
                }
                return true;
            }
            for (int i = 1; i <= N; i++)
            {
                cols[level + 1] = i;
                if (queens(level + 1))
                    return true;
            }
            return false;
        }

        public static bool promising(int level)
        {
            for (int i = 1; i < level; i++)
            {
                if (cols[i] == cols[level])
                    return false;
                else if (level - i == Math.Abs(cols[level] - cols[i]))
                    return false;
            }
            return true;
        }

        public static char[,] arr = new char[3071 ,6144];

        public static void starPrint()
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 2*n; j++)
                {
                    if (j == 2 * 1 - 1)
                        arr[i, j] = '\0';
                    else
                        arr[i, j] = ' ';
                }
            }

            star(n, n - 1, 0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 2 * n; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void star(int n, int x, int y)
        {
            if (n==3)
            {
                arr[y, x] = '*';
                arr[y + 1, x - 1] = '*';
                arr[y + 1, x + 1] = '*';
                arr[y + 2, x - 2] = '*';
                arr[y + 2, x - 1] = '*';
                arr[y + 2, x] = '*';
                arr[y + 2, x + 1] = '*';
                arr[y + 2, x + 2] = '*';
                return;
            }
            star(n / 2, x, y);
            star(n / 2, x - (n / 2), y + n / 2);
            star(n / 2, x + (n / 2 ), y + n / 2);
        }
    }
}
