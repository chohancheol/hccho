using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class _8_sample
    {

        int[,] board = {{0,1,1,1,0},
                                 {0,1,1,1,1},
                                 {0,0,1,1,1},
                                 {0,0,1,1,1},
                                 {0,0,0,0,0 }
                                };
        //가장큰 정사각형 그리기
        public int findLargestSquare()
        {

            int answer = 0;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    //board[i,j] = (board[i,j] == 'O') ? 1 : 0;

                    if (i == 0 || j == 0)
                        continue;

                    if (board[i,j] == 1)
                    {
                        board[i,j] = get_min(board[i - 1,j - 1], board[i - 1,j], board[i,j - 1]) + 1;
                        answer = (answer > board[i,j]) ? answer : board[i,j];
                    }
                }
            }

            return answer * answer;
        }

        int get_min(int a, int b, int c)
        {
            return (a > b) ? ((b > c) ? c : b) : ((a > c) ? c : a);
        }

    }
}
