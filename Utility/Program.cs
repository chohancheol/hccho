using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    class Program
    {
        static void Main(string[] args)
        {
            //Recursive.PowerSet(0);
            //Recursive.Permutation(0);
            //Recursive.PrintInBinary(32);

            //바이너리 검색
            //string[] data = { "1", "2", "3", "5", "7", "8", "9" };
            //int iPosition = Recursive.BinarySearch(data, "9", 0, data.Length);

            //Maze 찾기
            //Recursive.printMaze();
            //Recursive.FindMazePath(0, 0);
            //Recursive.printMaze();

            //Queen 배치
            //Recursive.queens(0);

            //Star Print
            //Recursive.starPrint();

            //LinkdedList
            LinkedList.LLMain();

            //Tree
            BinarySearch.BTSMain();

            //Version Sorting
            VersionSort.VSMain();

            Console.Read();
        }
    }


}
