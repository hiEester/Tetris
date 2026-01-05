using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tetris
{
    public class Game
    {

        public Shape current_shape;
        public Board board;
        public int source;

        public int level;
        public bool game_over = false;

        public Game(int size = 20)
        {
            Console.WriteLine("CTRIS");

            (int left, int top) start_point = Console.GetCursorPosition();
            board = new Board(size, start_point);
            Board next_board = new Board(size / 4, (start_point.left + size + 3, start_point.top));
            Board source_board = new Board(size / 3, (start_point.left + size + 3,
                start_point.top + size / 3 + 3));

            source = 0;
            level = 1;
        }
        public Shape random_shape()
        {  
            Random rnd = new Random();

            switch (rnd.Next(1, 4))
            {
                case 1:
                    return new Pas();
                case 2:
                    return new Plus();
                case 3:
                    return new Zig();
                case 4:
                    return new Zag();
                default:
                    return new Pas();
            }
        }

        public void start_game()
        {
            while (true)
            {
                if (game_over)
                {
                    Console.SetCursorPosition(board.size / 2, board.size / 2);
                    Console.Write("GAME OVER !!!!!");
                    break;
                }

                current_shape = random_shape();
                Put_shape();
                bool action_allowed = true;
                while (action_allowed)
                {
                   Thread.Sleep(250);
                   action_allowed &= TryMoveDown();
                    if (Console.KeyAvailable)
                        action_allowed &= Key_listener();
                }

                board.LockShape(current_shape.AbsoluteVertices);
                is_game_over();

            }
            while (!Console.KeyAvailable) { }
            Console.Clear();
        }


        public void Put_shape() { current_shape.SetAbsoluteVertices(board.start_point.top, board.size / 2); }
        private bool TryMoveDown() => TryMove(1,0);
        private bool TryMoveLeft() => TryMove(0,-1);
        private bool TryMoveRight() => TryMove(0, 1);
        private bool TryMove(int dx, int dy)
        {
            var candidate = current_shape.AbsoluteVertices.Select(v => (v.x + dx, v.y + dy));
            if (board.IsValid(candidate))
            {
                current_shape.Clear_shape();
                current_shape.Move(dx, dy);
                current_shape.Draw_shape();
                return true;
            }
            return false;
        }
        private bool TryRotate()
        {
            var candidate = current_shape.RotatedAbsoluteVertices();
            if (board.IsValid(candidate))
            {
                current_shape.Clear_shape();
                current_shape.SetAbsoluteVertices();
                current_shape.Draw_shape();
                return true;
            }
            current_shape.DisApplyRotation();

            return false;
        }
        private bool Key_listener()
        {
            var key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    return TryMoveLeft();
                case ConsoleKey.RightArrow:
                    return TryMoveRight();
                case ConsoleKey.UpArrow:
                    return TryRotate();
                case ConsoleKey.DownArrow:
                    return TryMoveDown();
                case ConsoleKey.Spacebar:
                    return current_shape.Spacebar(this);
                default:
                    return false;
            }

        }
        public void is_game_over()
        {
            game_over = current_shape.AbsoluteVertices
                .Any(s => s.x - 1 == board.start_point.top);
















































































































        }

    }
}
