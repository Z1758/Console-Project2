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

        static public int towerLimitCount;

        static public int stageTime;

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

         

            if (RandomTowerDefense.mode == 0)
            {
                enemyLimitCount = 80;
                enemySetOneStage = 50;
                userGold = 1000;
                towerLimitCount = (Map.widthCenter - 2) * (Map.heightCenter - 2);

                stageTime = 60;
            }
            else if (RandomTowerDefense.mode == 1)
            {
                enemyLimitCount = 60;
                enemySetOneStage = 30;
                userGold = 200;
                towerLimitCount = Map.userSpaceCnt;
                stageTime = 40;
            }
            currentStage = 1;
            enemyCount = 0;
            bossStage = false;
        }


        static public void SetEnemyInformation()
        {
            
                EnemyInformations.Add(1, new EnemyInfo { hp = 100, moveSpeed = 4, dropGold = 10 + RandomTowerDefense.mode * 10 });
                EnemyInformations.Add(2, new EnemyInfo { hp = 250, moveSpeed = 5, dropGold = 10 + RandomTowerDefense.mode * 10 });
                EnemyInformations.Add(3, new EnemyInfo { hp = 250, moveSpeed = 2, dropGold = 10 + RandomTowerDefense.mode * 10 });
                EnemyInformations.Add(4, new EnemyInfo { hp = 500, moveSpeed = 6, dropGold = 10 + RandomTowerDefense.mode * 10 });
                EnemyInformations.Add(5, new EnemyInfo { hp = 650, moveSpeed = 4, dropGold = 10 + RandomTowerDefense.mode * 10 });
                EnemyInformations.Add(6, new EnemyInfo { hp = 750, moveSpeed = 4, dropGold = 10 + RandomTowerDefense.mode * 10 });
                EnemyInformations.Add(7, new EnemyInfo { hp = 800, moveSpeed = 4, dropGold = 10 + RandomTowerDefense.mode * 10 });
                EnemyInformations.Add(8, new EnemyInfo { hp = 700, moveSpeed = 2, dropGold = 10 + RandomTowerDefense.mode * 10 });
                EnemyInformations.Add(9, new EnemyInfo { hp = 1200, moveSpeed = 6, dropGold = 10 + RandomTowerDefense.mode * 10 });
                EnemyInformations.Add(10, new EnemyInfo { hp = 15000, moveSpeed = 4, dropGold = 100 });
                EnemyInformations.Add(11, new EnemyInfo { hp = 50000, moveSpeed = 4, dropGold = 100 });
            
           
            }

      
    }
}
