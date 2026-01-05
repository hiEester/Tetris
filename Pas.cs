using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Pas : Shape
    {

        public Pas() : base()
        { }
        protected override ConsoleColor Color { get; set; } = ConsoleColor.Red;

        protected override List<List<(int x, int y)>> vertices { get; set; } = new()
            {
               new List<(int x, int y)>
               {
                (0, 0),
                (0, 1),
                (0, 2),
                (0, 3), },

               new List<(int x, int y)>
               {
                (-3,3 ),
                (-2,2),
                (-1,1 ),
                (0,0), },
                new List<(int x, int y)>
               {
                (0,0 ),
                (-1,1),
                (-2,2 ),
                (-3,3), }
            };


    }
}



