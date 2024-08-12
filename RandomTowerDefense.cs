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
            
            Player player = Player.Instance();

            gameManager = GameManager.Instance();
            gameManager.SetPlayer(player);

            TimeManager.TimerInit();
        }


        static public void Update()
        {
            Map.DynamicDraw();
            gameManager.CheckDraw();

            Map.DrawPixel();

            gameManager.InputKey();

            ClearBuffer();
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

        //키 입력 버퍼 지우기
        static void ClearBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(false);
            }
        }

    }
}
