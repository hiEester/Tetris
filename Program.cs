// :מחלקה אבסטרקטית של צורה
//צבע, 
// פונקציות: ימינה שמאלה  למטה והיפוך
// 6 מחלקות כל פעם של צורה אחרת 
// :מחלקה של לוח 
// האם שורה היא תפוסה או לא
// האם גיים אובר
// אפשרות של הוזזה של החיצים 
//הצורה הבאה
//הצורה הנוכחית 
//נקודות
// רמה 
// מהירות ירידת הצורה   
// מחלקה משחק

using ConsoleApp1;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{


    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.start_game();
            
            Shape n = new Plus(20 );
           
            Shape ns = new Pas(20);




            Console.ReadLine();
        }
    }

}