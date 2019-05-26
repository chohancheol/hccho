using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class _86_Matrix_1
    {
        public void Test()
        {
            string[,] aaaa = { { "0", "0", "0", "1", "1",   "1", "1", "0", "0", "0" },
                               { "0", "1", "1", "0", "0",   "0", "1", "0", "0", "0" },
                               { "0", "0", "0", "0", "0",   "0", "1", "0", "0","0" },
                               { "0", "0", "0", "0", "0",   "1", "1", "1", "1", "0" },
                               { "0", "0", "0", "0", "0",   "1", "1", "1", "1", "0" },
                               { "1", "1", "1", "1", "0",   "0", "1", "0", "0", "0" },
                               { "0", "0", "0", "0", "0",   "0", "1", "0", "0", "0" },
                               { "0", "0", "0", "0", "0",   "0", "1", "0", "0", "0" },
                               { "0", "0", "0", "0", "0",   "0", "1", "0", "0", "0" }};


            List<string> myListPosition = new List<string>();
            iCnt(aaaa, 0, 6, 0, myListPosition);

            List<List<string>> iList1 = new List<List<string>>();

            for (int i = 0; i < aaaa.GetLength(0); i++)
            {
                for (int j = 0; j < aaaa.GetLength(1); j++)
                {
                    List<string> myList = new List<string>();
                    iCnt(aaaa, i, j, 0, myList);

                    if (myList.Count > 0)
                    {
                        if (iList1.Count == 0)
                        {
                            iList1.Add(myList);
                        }
                        else
                        {
                            bool bflag = false;
                            foreach (List<string> item in iList1)
                            {
                                if (item.Contains(myList[0]))
                                {
                                    bflag = true;
                                }
                            }

                            if (!bflag)
                                iList1.Add(myList);
                        }
                    }

                }
            }
        }

        //private static List<string> iList = new List<string>();


        private static int iValue = 0;
        public static void iCnt(string[,] aaaa, int irow, int icol, int ioption, List<string> myList)
        {
            if (irow < 0 || icol < 0 || irow >= aaaa.GetLength(0) || icol >= aaaa.GetLength(1))
                return;

            if (aaaa[irow, icol] == "1")
            {
                if (!myList.Contains(irow + "," + icol))
                {
                    myList.Add(irow + "," + icol);
                    iValue++;
                }
                else
                    return;

            }
            else
                return;

            //top
            if (ioption != 1)
                iCnt(aaaa, irow - 1, icol, 3, myList);

            //right
            if (ioption != 2)
                iCnt(aaaa, irow, icol + 1, 4, myList);

            //bottom
            if (ioption != 3)
                iCnt(aaaa, irow + 1, icol, 1, myList);

            //left
            if (ioption != 4)
                iCnt(aaaa, irow, icol - 1, 2, myList);

            return;
        }
    }
}
