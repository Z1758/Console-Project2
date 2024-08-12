using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
    public class Player
    {
        private static Player playerSingleton;
        public static Player Instance()
        {
            if (playerSingleton == null)
            {
                playerSingleton = new Player();
            }

            return playerSingleton;

        }
    }
}
