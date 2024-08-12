using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
    static public class TimeManager
    {
        static public int roundTime;
        static public int roundCount ;

        static System.Timers.Timer enemyTickTimer;
        static System.Timers.Timer towerTickTimer;
        static System.Timers.Timer roundTimer;

        static public event Action RoundEvent;
        static public event Action NextStage;

        static public void TimerInit()
        {
            roundTime = 60;
            roundCount = roundTime;

            enemyTickTimer = new System.Timers.Timer();
            enemyTickTimer.Interval = 100; //0.1초마다

            towerTickTimer = new System.Timers.Timer();
            towerTickTimer.Interval = 100; //0.1초마다


            roundTimer = new System.Timers.Timer();
            roundTimer.Interval = 1000; //1초마다
            roundTimer.Elapsed += new System.Timers.ElapsedEventHandler(RoundTimer);


            enemyTickTimer.Start();
            towerTickTimer.Start();
            roundTimer.Start();
        }

        static void RoundTimer(object sender, System.Timers.ElapsedEventArgs e)
        {

            roundCount--;
            if (roundCount == 0)
            {
                roundCount = roundTime;
                StageManager.currentStage++;
                NextStage();

            }

            if(roundTime - StageManager.enemySetOneStage <= roundCount)
                RoundEvent();

        }


        static public void AddEnemyMoveEvent(Enemy enemy)
        {

            enemyTickTimer.Elapsed += new System.Timers.ElapsedEventHandler(enemy.MoveEnemy);
        }

        static public void RemoveEnemyMoveEvent(Enemy enemy)
        {

            enemyTickTimer.Elapsed -= new System.Timers.ElapsedEventHandler(enemy.MoveEnemy);
        }

        static public void AddTowerAttackEvent(Tower tower)
        {

            towerTickTimer.Elapsed += new System.Timers.ElapsedEventHandler(tower.AttackTower);
        }

        static public void RemoveTowerAttackEvent(Tower tower)
        {

            towerTickTimer.Elapsed -= new System.Timers.ElapsedEventHandler(tower.AttackTower);
        }


    }
}
