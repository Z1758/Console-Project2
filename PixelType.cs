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
        public const int BOSS = 100;

        public const int RANDOMUSERSPACE = 501;
        public const int RANDOMENEMYPATH = 502;

        public const int OVERLAPPLAYERENEMY = 600;
        public const int OVERLAPPLAYERBOSS = 650;
        public const int OVERLAPPLAYERPATH = 700;

        public const int GRADE_C_START = 1001;
        public const int GRADE_C_POWER = 1001;
        public const int GRADE_C_SPEED = 1002;
        public const int GRADE_C_RANGE = 1003;
        public const int GRADE_C_END = 1004;

        public const int GRADE_B_START = 2001;
        public const int GRADE_B_POWER = 2001;
        public const int GRADE_B_SPEED = 2002;
        public const int GRADE_B_RANGE = 2003;
        public const int GRADE_B_END = 2004;

        public const int GRADE_A_START = 3001;
        public const int GRADE_A_POWER = 3001;
        public const int GRADE_A_SPEED = 3002;
        public const int GRADE_A_RANGE = 3003;
        public const int GRADE_A_END = 3004;

        public const int GRADE_S_START = 4001;
        public const int GRADE_S_POWER = 4001;
        public const int GRADE_S_SPEED = 4002;
        public const int GRADE_S_RANGE = 4003;
        public const int GRADE_S_END = 4004;

        public const int GRADE_C = 1000;
        public const int GRADE_B = 2000;
        public const int GRADE_A = 3000;
        public const int GRADE_S = 4000;

        public const int COOLDOWNTOWER = 6666;


        public const int END = 99999;
    }
}
