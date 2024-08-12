using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
    

    static public class PixelType
    {
        public const int WALL = 0;
        public const int USERSPACE = 1;
        public const int ENEMYPATH = 2;
        public const int PLAYER = 3;
        public const int ENEMY = 4;
        public const int ENEMIES = 5;

        public const int GRADE_C_START = 1001;
        public const int GRADE_C_POWER = 1001;
        public const int GRADE_C_SPEED = 1002;
        public const int GRADE_C_RANGE = 1003;
        public const int GRADE_C_END = 1004;

        public const int GRADE_C = 1000;
        public const int GRADE_B = 2000;
        public const int GRADE_A = 3000;
        public const int GRADE_S = 4000;


       
      

        /* 타워 종류
       Console.ForegroundColor = ConsoleColor.Yellow;
       Console.WriteLine("㉿㉿㉿");
       Console.WriteLine("♨♨♨");
       Console.WriteLine("☎☎☎");
       Console.ResetColor();

       Console.ForegroundColor = ConsoleColor.Red;
       Console.WriteLine("♬♬♬");
       Console.WriteLine("●●●");
       Console.WriteLine("♣♣♣");
       Console.ResetColor();

       Console.ForegroundColor = ConsoleColor.Green;
       Console.WriteLine("★★★");
       Console.WriteLine("◈◈◈");
       Console.WriteLine("♥♥♥");
       Console.ResetColor();

       Console.ForegroundColor = ConsoleColor.Cyan;
       Console.WriteLine("☆☆☆");
       Console.WriteLine("◇◇◇");
       Console.WriteLine("♡♡♡");
       Console.ResetColor();
       return;
       */

        public const int END = 99999;
    }
}
