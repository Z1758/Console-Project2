using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleProject2
{
    public class RandomTowerDefense
    {

        static GameManager gameManager;
        static public void Init()
        {

            Map.PixelInit();
            StageManager.StageManagerInit();

            Player player = Player.Instance();

            gameManager = GameManager.Instance();
            gameManager.SetPlayer(player);
            gameManager.CurrentEnemyInfoSet();

            TimeManager.TimerInit();
        }


        static public void Update()
        {
            Map.DynamicDraw();
            gameManager.CheckDraw();

            Map.DrawPixel();

            gameManager.InputKey();

           
        }

        static public bool EndGameCheck()
        {
            if (StageManager.enemyCount >= StageManager.enemyLimitCount || StageManager.currentStage > 10)
            {
                TimeManager.EndTimer();
                return false;

            }

            return true;
        }

        static public void EndGame(){
            GamaOver.OutPutGameOver( StageManager.enemyCount == 0 );
        }


        static void Main(string[] args)
        {

            GameStart.StartScene();
            Init();



            

            

            while (EndGameCheck())
            {
                Update();
                
            }
            EndGame();

        }

    }



   
}
