using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
    static public class TimeManager
    {
        static public int roundCount = 60;

        static System.Timers.Timer tickTimer;
        static System.Timers.Timer roundTimer;

        static public event Action RoundEvent;


        static public void TimerInit()
        {
            tickTimer = new System.Timers.Timer();
            tickTimer.Interval = 100; //0.1초마다


            roundTimer = new System.Timers.Timer();
            roundTimer.Interval = 1000; //1초마다
            roundTimer.Elapsed += new System.Timers.ElapsedEventHandler(RoundTimer);


            tickTimer.Start();
            roundTimer.Start();
        }

        static void RoundTimer(object sender, System.Timers.ElapsedEventArgs e)
        {

            roundCount--;
            RoundEvent();

        }


        static public void AddEnemyMoveEvent(Enemy enemy)
        {

            tickTimer.Elapsed += new System.Timers.ElapsedEventHandler(enemy.MoveEnemy);
        }


       


    }
}
