using System;

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
            Map.ArrDraw();
            gameManager.CheckEnemy();

            Map.DrawPixel();
        }
        static void Main(string[] args)
        {
            Init();


            //임시 나중에 수정
            gameManager.CurrentEnemyInfoSet();
           

           
        
          



            while (true)
            {
                Update();
            }

        }
    }
}
