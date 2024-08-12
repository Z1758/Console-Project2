using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
    
    public class GameManager 
    {

        public int enemyCount;

        static public int enemyLimitCount ;
        static public int enemySetOneStage;
     

        public EnemyInfo curEnemyInfo;

        Queue<Enemy> disabledEnemyQueue = new Queue<Enemy>();

        List<Enemy> activeEnemies = new List<Enemy>();

        Queue<Tower> towerQueue = new Queue<Tower>();

        private GameManager()
        {
            enemyLimitCount = 80;
            enemySetOneStage = 5;
            enemyCount = 0;
            InitEnemy();
            TimeManager.RoundEvent += SetEnemyStagePerSecond;
        }

        public void SetEnemyStagePerSecond()
        {
            if (enemyCount < enemySetOneStage)
            {
                SetEnemy();
            }
        }

        public void CheckEnemy()
        {
            for (int i = 0; i < activeEnemies.Count; i++)
            {
                if (Map.pixelNum[activeEnemies[i].posY, activeEnemies[i].posX] >= PixelType.ENEMIES)
                {
                    Map.pixelNum[activeEnemies[i].posY, activeEnemies[i].posX]++;
                }
                else if (Map.pixelNum[activeEnemies[i].posY, activeEnemies[i].posX] == PixelType.ENEMY)
                {
                    
                    Map.pixelNum[activeEnemies[i].posY, activeEnemies[i].posX] = PixelType.ENEMIES;
                }
                else
                {
                    Map.pixelNum[activeEnemies[i].posY, activeEnemies[i].posX] = PixelType.ENEMY;
                }
              
            }
        }

        public void SetEnemy()
        {
            if (disabledEnemyQueue.Count <= 0)
            {
                return;
            }
            Enemy enemy = disabledEnemyQueue.Dequeue();
            enemy.EnemyInitStatus(curEnemyInfo.hp, curEnemyInfo.moveSpeed, curEnemyInfo.dropGold);
           
            TimeManager.AddEnemyMoveEvent(enemy);
            activeEnemies.Add(enemy);
            enemyCount++;

            //임시 나중에 수정
            curEnemyInfo = StageManager.EnemyInformations[enemyCount];
        }

        public void CurrentEnemyInfoSet()
        {
            //임시 나중에 수정
            curEnemyInfo = StageManager.EnemyInformations[1];
        }

        public void InitEnemy()
        {
            for (int i = 0; i < enemyLimitCount; i++)
            {
                disabledEnemyQueue.Enqueue(new Enemy() );
            }
        }

    


        private static GameManager gmSingleton;
        public static GameManager Instance()
        {
            if (gmSingleton == null)
            {
                gmSingleton = new GameManager();
               
              

            }

            return gmSingleton;

        }
    }
}
