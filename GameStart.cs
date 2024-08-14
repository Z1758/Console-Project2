using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
    static public class GameStart
    {

        static public void StartScene()
        {

            Console.ForegroundColor = ConsoleColor.White;
            string[] title =
{"    ■■       ■■■      ■■\n",
"    ■ ■        ■        ■ ■\n",
"    ■■         ■        ■ ■\n",
"    ■ ■        ■        ■ ■\n",
"    ■ ■        ■        ■■\n" };
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < title.Length; i++)
            {
                Console.Write(title[i]);
                Thread.Sleep(200);
            }
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
           
            Console.WriteLine("        Random Tower Defense");
            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("       press any key to start");


            Console.CursorVisible = false;

            Console.ReadKey();

            Console.ResetColor();

            Console.Clear();

        }
    }
}
