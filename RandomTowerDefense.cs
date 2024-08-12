using System;
using System.Diagnostics;

namespace ConsoleProject2
{
    public class RandomTowerDefense
    {
     
        static GameManager gameManager;
        static public void Init()
        {
   
            Map.PixelInit();
            StageManager.StageManagerInit();
            
            gameManager = GameManager.Instance();

            TimeManager.TimerInit();
        }


        static public void Update()
        {
            Map.DynamicDraw();
            gameManager.CheckDraw();

            Map.DrawPixel();
        }
        static void Main(string[] args)
        {
            Init();


            //임시 나중에 수정
            gameManager.CurrentEnemyInfoSet();






            gameManager.SetTower();

            while (true)
            {
                Update();
            
            }

        }
    }
}
