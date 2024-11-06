using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Board
    {
        PlayerEnum[,] board = new PlayerEnum[3,3];

        public Board()
        {
            for (int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    board[x, y] = PlayerEnum.NONE;
                }  
            }
        }
    }
}
