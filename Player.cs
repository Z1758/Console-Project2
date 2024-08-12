using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
    public class Player
    {
        private int posX, posY;
      
        

        private static Player playerSingleton;

   
        public int PosX { get => posX; set => posX = value; }
        public int PosY { get => posY; set => posY = value; }

        Player()
        {
            posX = Map.centerPos;
            posY = Map.centerPos;
        }

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
