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
        static private int userGold;

        static public int currentStage;
        static public int enemyLimitCount;
        static public int enemySetOneStage;
        static public int enemyCount;

        static bool bossStage;

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

            enemyLimitCount = 80;
            enemySetOneStage = 50;
            userGold = 1000;
            currentStage = 9;
            enemyCount = 0;
            bossStage = false;
        }



        static public void SetEnemyInformation()
        {
            EnemyInformations.Add(1, new EnemyInfo { hp = 100,  moveSpeed = 8, dropGold = 10 });
            EnemyInformations.Add(2, new EnemyInfo { hp = 150, moveSpeed = 9, dropGold = 10 });
            EnemyInformations.Add(3, new EnemyInfo { hp = 100, moveSpeed = 3, dropGold = 10 });
            EnemyInformations.Add(4, new EnemyInfo { hp = 500, moveSpeed = 20, dropGold = 10 });
            EnemyInformations.Add(5, new EnemyInfo { hp = 400, moveSpeed = 8, dropGold = 10 });
            EnemyInformations.Add(6, new EnemyInfo { hp = 500, moveSpeed = 8, dropGold = 10 });
            EnemyInformations.Add(7, new EnemyInfo { hp = 650, moveSpeed = 9, dropGold = 10 });
            EnemyInformations.Add(8, new EnemyInfo { hp = 500, moveSpeed = 3, dropGold = 10 });
            EnemyInformations.Add(9, new EnemyInfo { hp = 900, moveSpeed = 20, dropGold = 10 });
            EnemyInformations.Add(10, new EnemyInfo{ hp = 12000, moveSpeed = 7, dropGold = 100 });
            EnemyInformations.Add(11, new EnemyInfo { hp = 12000, moveSpeed = 7, dropGold = 100 });
        }

      
    }
}
