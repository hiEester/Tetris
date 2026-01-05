using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public interface IBoard
    {
        public void LockShape(List<(int x, int y)> positions);
        public bool IsValid(IEnumerable<(int x, int y)> positions);
        int Rows { get; }
        int Cols { get; }
    }
}
