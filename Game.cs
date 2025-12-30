using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Game
    {
        public (int x, int y)[][] board;
        public int board_size;
        public int next_shape_size;
        public int source_size;
        public int source;
        public int removed_lines;
        public int level;

        public static (int top, int left) start_point;
        public static ConsoleColor default_color;

        public Shape current_shape;
        public Shape next_shape;
        public static ConsoleColor Default_colorl()
        {
            if (default_color == null)
            {
                default_color = Console.BackgroundColor;
            }
            return default_color;
        }
        public Game(int size = 20)
        {
            Default_colorl();
            this.board_size = size;
            this.next_shape_size = size / 4;
            this.source_size = size / 3;
            Console.WriteLine("CTRIS");
            this.print_board();

            board = new (int x, int y)[2][] {
            new (int x, int y)[4],
            new (int x, int y)[4]
        };

            source = 0;
            level = 1;
        }

        public void print_board()
        { 
            print_board_side(this.board_size);
            
            print_board_side(this.next_shape_size);
            Console.WriteLine("");

            for (int i = 0; i < board_size; i++)
            {
                print_board_line(board_size, i >= next_shape_size && i > source_size + next_shape_size);

                if (i < this.next_shape_size)//print the next shape board
                {
                    print_board_line(this.next_shape_size, true);


                }
                if (i == this.next_shape_size)
                {
                    print_board_side(this.next_shape_size);
                    Console.WriteLine("");

                }
                if (i > next_shape_size && i < next_shape_size + source_size)//print the source board
                {
                    print_board_line(this.source_size, true);

                }
                if (i == this.next_shape_size + source_size)
                {
                    print_board_side(this.source_size);
                    Console.WriteLine("");
                }


            }
            print_board_side(this.board_size);
            Console.WriteLine("");
        }
        public void print_board_side(int _size)
        {
            Console.Write(" ");
            Game.start_point = Console.GetCursorPosition();
            Game.start_point.left = board_size / 2;
            for (int i = 0; i < _size; i++)
            {
                Console.Write("_");
            }
          
        }
        public void print_board_line(int _size, bool is_write_line = false)
        {
            Console.Write("|");
            for (int j = 0; j < _size; j++)
            {
                Console.Write(" ");
            }
            if (!is_write_line)
                Console.Write("|");
            else
                Console.WriteLine("|");
        }
        public void start_game()
        {

            next_shape = random_shape();
            while (true)
            {

                if (game_over())
                    break;
                current_shape = next_shape;
                next_shape = random_shape();
                while (true)
                {
                    //Console.SetCursorPosition(0, this.board_size);
                    
                    current_shape.down();
                    int interation = 1;
                    while (interation < this.board_size)
                    {


                        current_shape.play_shape(interation++);
                    }
                }



            }


        }
        public Shape random_shape() { return new Plus(20); }
        public bool game_over() { return false; }
    }

}
