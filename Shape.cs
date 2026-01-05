using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Shape
    {
        protected abstract ConsoleColor Color { get; set; }
        protected abstract List<List<(int x, int y)>> vertices { get; set; }

        private int _rotationIndex = 0;
        public int RotationIndex
        {
            get => _rotationIndex;
            set
            {

                if (value >= vertices.Count)
                    _rotationIndex = 1;
                else
                    _rotationIndex = value;
            }
        }



        public List<(int x, int y)> AbsoluteVertices { get; private set; }
        public List<(int x, int y)> RotatedAbsoluteVertices() =>
            vertices[RotationIndex++].Select((r,i) => (r.x + AbsoluteVertices[i].x, r.y + AbsoluteVertices[i].y)).ToList();
        public void SetAbsoluteVertices (int x, int y) => AbsoluteVertices = vertices[0].Select(s => (s.x + x, s.y + y)).ToList();
        public void SetAbsoluteVertices (List<(int x, int y)>s) => AbsoluteVertices = vertices[RotationIndex].Zip(s, (a, b) => (a.x + b.x, a.y + b.y)).ToList();
        public void SetAbsoluteVertices() => AbsoluteVertices = vertices[RotationIndex].Select((r, i) => (r.x + AbsoluteVertices[i].x, r.y + AbsoluteVertices[i].y)).ToList();

        

        public void Move(int dx, int dy) => AbsoluteVertices = AbsoluteVertices.Select(s=>(s.x + dx, s.y + dy)).ToList();
        public void DisApplyRotation() => RotationIndex = RotationIndex --;
        public bool Spacebar(Game g) { return true; }
        public void Draw_shape()
        {
            Console.BackgroundColor = Color;
            foreach (var (x, y) in AbsoluteVertices)
            {
                Console.SetCursorPosition(y, x);
                Console.Write(" ");
            }
            Console.BackgroundColor = Board.default_color;
        }
        public void Clear_shape()
        {
            foreach (var (x, y) in AbsoluteVertices)
            {
                Console.SetCursorPosition(y, x);
                Console.Write(" ");
            }
        }

        public void Draw_rotate_shape()
        {
            Console.BackgroundColor = Color;
            foreach (var (x, y) in RotatedAbsoluteVertices().Zip(AbsoluteVertices, (a, b) => (a.x + b.x, a.y + b.y)).ToList())
            {
                Console.SetCursorPosition(y, x);
                Console.Write(" ");
            }
            Console.BackgroundColor = Board.default_color;
        }
        public void Clear_rotate_shape()
        {
            foreach (var (x, y) in RotatedAbsoluteVertices().Zip(AbsoluteVertices, (a, b) => (a.x + b.x, a.y + b.y)).ToList())
            {
                Console.SetCursorPosition(y, x);
                Console.Write(" ");
            }
        }
    }

}

