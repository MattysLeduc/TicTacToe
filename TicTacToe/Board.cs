using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Board
    {
        PlayerEnum[,] board = new PlayerEnum[3,3];

        public Board()
        {

            Reset();
        }

        public bool Select(int row, int col, PlayerEnum player)
        {
            if (board[row, col] == PlayerEnum.NONE)
            {
                board[row, col] = player;
                return true;
            }
            return false;
        }

        public bool CheckWin(out PlayerEnum winner)
        {
            // Check rows, columns, and diagonals for a win
            winner = PlayerEnum.NONE;

            // Check rows and columns
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != PlayerEnum.NONE)
                {
                    winner = board[i, 0];
                    return true;
                }
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != PlayerEnum.NONE)
                {
                    winner = board[0, i];
                    return true;
                }
            }

            // Check diagonals
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != PlayerEnum.NONE)
            {
                winner = board[0, 0];
                return true;
            }
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != PlayerEnum.NONE)
            {
                winner = board[0, 2];
                return true;
            }

            return false;
        }

        public bool CheckDraw()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (board[x, y] == PlayerEnum.NONE)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CheckEndCondition(out PlayerEnum winner)
        {
            if (CheckWin(out winner))
            {

                Reset();
                return true;
            }
            else if (CheckDraw())
            {

                winner = PlayerEnum.NONE;
                Reset();
                return true;
            }


            winner = PlayerEnum.NONE;
            return false;
        }



        public void Reset()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    board[x, y] = PlayerEnum.NONE;
                }
            }
        }
    }
}


