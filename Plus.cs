using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Plus : Shape
    {

        public Plus(int bourd_size):base( bourd_size)
        {
            this.color = ConsoleColor.Blue;
            this.vertices = new (int x, int y)[4];
            this.vertices[0] = (0, 1);
            this.vertices[1] = (1, 0);
            this.vertices[2] = (1, 1);
            this.vertices[3] = (1, 2);
            this.Put_shape(bourd_size);

        }

        public override void play_shape(int interation)
        {
           
                Thread.Sleep(100);
                this.print(interation);
                Thread.Sleep(100);
                this.clear(interation);
            
        }
        public override void clear(int interation)
        {
            
            this.SetCursorPosition(1, interation);
            Console.WriteLine(" ");
            this.SetCursorPosition(0, interation+1);
            Console.Write(" ");
          
            Console.Write("   ");
         
            this.SetCursorPosition(0, interation+2);
            Console.Write("     ");

            Console.WriteLine("");
        }
        public override void print(int interation)
        {
            this.SetCursorPosition(1, interation);
            Console.WriteLine("_");
           

            this.SetCursorPosition(0,interation+1);
            
  
            Console.Write("_");
            Console.BackgroundColor = this.color;
            Console.Write("||");
            Console.BackgroundColor = Game.Default_colorl();
            Console.Write("_");
            Console.BackgroundColor = this.color;
            this.SetCursorPosition(0, interation+2);
            Console.Write("|___|");
            Console.BackgroundColor = Game.Default_colorl();
         
            Console.WriteLine("");
            
        }
    }

}

