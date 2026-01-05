namespace Tetris
{
    public class Zag : Shape
    {
        protected override ConsoleColor Color { get; set; } = ConsoleColor.Green;

        protected override List<List<(int x, int y)>> vertices { get; set; } = new()
        {
            new List<(int x, int y)> { (0, 0),
            (0, 1),
            (1, 1),
            (1, 2), },
             new List<(int x, int y)> {
            (0, 0),
            (0, 3),
            (1, 1),
            (1, 2),
            }

        };

        public Zag() : base() { }




    }

}
