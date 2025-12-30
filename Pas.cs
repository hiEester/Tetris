using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Pas : Shape
    {

        public Pas(int bourd_size):base(bourd_size)
        {
            this.color = ConsoleColor.Red;
            this.vertices = new (int x, int y)[4];
            this.vertices[0] = (0, 0);
            this.vertices[1] = (0, 1);
            this.vertices[2] = (0, 2);
            this.vertices[3] = (0, 3);
            this.Put_shape(bourd_size);
        }

        public override void clear(int interation)
        {
            throw new NotImplementedException();
        }

        public override void play_shape(int interation)
        {
            throw new NotImplementedException();
        }

        public override void print(int interation)
        {
            Console.Write(" ");
            Console.Write("_");
            Console.Write("_");
            Console.Write("_");
            Console.WriteLine("_");

            Console.Write("|");
            Console.Write("_");
            Console.Write("_");
            Console.Write("_");
            Console.Write("_");
            Console.Write("|");
           

          
        }
    }
}

