using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
     public struct EnemyInfo
    {
     
        public int hp;
        public double moveSpeed;
        public int dropGold;
    }
   



    static public class StageManager
    {
        private static int userGold;

        public static Dictionary<int,EnemyInfo> EnemyInformations;
        
        static public void SetGold(int gold)
        {
            userGold += gold;
        }

        static public int GetGold()
        {
            return userGold;
        }


        static public void StageManagerInit()
        {
            EnemyInformations = new Dictionary<int, EnemyInfo>();
            SetEnemyInformation();

            userGold = 1000;
        }



        static public void SetEnemyInformation()
        {
            EnemyInformations.Add(1, new EnemyInfo { hp = 100,  moveSpeed = 10, dropGold = 10 });
            EnemyInformations.Add(2, new EnemyInfo { hp = 150, moveSpeed = 9, dropGold = 10 });
            EnemyInformations.Add(3, new EnemyInfo { hp = 100, moveSpeed = 3, dropGold = 10 });
            EnemyInformations.Add(4, new EnemyInfo { hp = 500, moveSpeed = 20, dropGold = 10 });
            EnemyInformations.Add(5, new EnemyInfo { hp = 400, moveSpeed = 10, dropGold = 10 });
          
        }

      
    }
}
