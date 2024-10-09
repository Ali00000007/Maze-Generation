using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    class Cell
    {
        public int row;
        public int col;
        public bool wallright;
        public bool walldown;
        public bool visited;
        public Cell(int i, int j)
        {
            row = i;
            col = j;
            visited = false;
            wallright = true;
            walldown = true;
        }
        public static void breakwall(int row, int col, int row2, int col2, ref Cell[,] maze)
        {
            if (row < row2)
            {
                maze[row, col].walldown = false;
            }
            else if (row2 < row)
            {
                maze[row2, col2].walldown = false;
            }
            else if (col < col2)
            {
                maze[row, col].wallright = false;
            }
            else if (col2 < col)
            {
                maze[row2, col2].wallright = false;
            }
        }

    }
}
