using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Zig : Shape
    {
        protected override ConsoleColor Color { get; set; } = ConsoleColor.Magenta;

        protected override List<List<(int x, int y)>> vertices { get; set; } = new()
        {
            new List<(int x, int y)>{
            (0, 0),
            (0, 1),
            (1, 1),
            (2, 1) },
           new List<(int x, int y)>{
                (1,0 ),
                (0,1),
                (0,0),
                (-1,1)
            },
            new List<(int x, int y)>{
                (1,1 ),
                (0,-1),
                (0,0),
                (1,0)
            },
             new List<(int x, int y)>{
                (0,-1),
                (1,-1),
                (0,0),
                (-1,0)
            },
             new List<(int x, int y)>{
                (-2,0),
                (-1,1),
                (0,0),
                (1,-1)
            },

        };
      
        public Zig() : base()
        { }


    }
}
