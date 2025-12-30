using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Shape

    {
        public abstract void play_shape(int interation);
        public abstract void clear(int interation);
        public ConsoleColor color;
        
        public (int x, int y)[] vertices;

        public int bourd_size;
        
        public Shape(int bourd_size)
        {
            this.bourd_size = bourd_size;

        }
        public void Put_shape(int bourd_size)
        {
            for (int i = 0; i < this.vertices.Length; i++)
            {
                this.vertices[i].y += 1;
                this.vertices[i].x += bourd_size / 2;
            }

        }

        public void SetCursorPosition(int left = 0, int top = 0)
        {
            Console.SetCursorPosition(Game.start_point.left + left, Game.start_point.top + top);
        }
        public void down()
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].y += 1;
            }

        }
        public void left()
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].x -= 1;
            }

        }
        public void right()
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].x += 1;
            }
        }
        public void oppsite() { }

        public abstract void print(int interation);

        
    }

}

