using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Board : IBoard
    {

        public bool[,] grid;


        public int size;
        public int next_shape_size;
        public int source_size;
        public (int left, int top) start_point;
        public static ConsoleColor default_color;
        public int Rows => grid.GetLength(0);
        public int Cols => grid.GetLength(1);

        public Board(int size, (int left, int top) _start_point)
        {
            this.size = size;
            start_point = _start_point;
            default_color = Console.BackgroundColor;

            DrawBoard(size, start_point.left, start_point.top);


            grid = new bool[size + start_point.top + 2, size];
        }

        public void LockShape(List<(int x, int y)> positions)
        {
            foreach (var (x, y) in positions) grid[x, y] = true;
        }
        public bool IsValid(IEnumerable<(int x, int y)> positions)
        {
            foreach (var pos in positions)
            {
            
                if (pos.x < 0 || pos.x >= size + start_point.top + 1 || pos.y < 0 || pos.y >= size + start_point.left)
                    return false;

                // תפוס?
                if (grid[pos.x, pos.y])
                    return false;
            }
            return true;
        }
        public void DrawBoard(int size, int left, int top)
        {
            print_line_width(size, (left + 1, top));
            print_line_height(size, (left, top + 1));
            print_line_width(size, (left + 1, top + size + 1));
            print_line_height(size, (left + 1 + size, top + 1));
        }
        public void print_line_width(int _size, (int left, int top) points)

        {
            Console.SetCursorPosition(points.left++, points.top);
            for (int i = 0; i < _size; i++)
            {
                Console.Write("-");
            }
        }
        public void print_line_height(int _size, (int left, int top) points)
        {
            for (int i = 0; i < _size; i++)
            {
                Console.SetCursorPosition(points.left, points.top++);
                Console.Write("|");
            }


        }
    }
}