using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleProject2
{
    public class RandomTowerDefense
    {

        public static GameManager gameManager;

        public static int mode;

        static public void Init()
        {

            

            StageManager.StageManagerInit();

            Player player = Player.Instance();

            gameManager = GameManager.Instance();
            gameManager.SetPlayer(player);
            gameManager.CurrentEnemyInfoSet();

            TimeManager.TimerInit();
        }


        static public void Update()
        {
            if (mode == 0)
            {
                Map.DynamicDraw();
            }
            else
            {
                Map.DynamicRandomDraw();
            }

           
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
            SelectMode();
            switch (mode)
            {
                case 0:
                    Map.PixelMode1Init();
                    break;
                case 1:
                    Map.PixelMode2Init();
                    break;

            }

      
            
            Init();



            while (EndGameCheck())
            {
                Update();
                
            }
            EndGame();

        }

        static public void SelectMode()
        {
            ClearBuffer();
            int select = 0;
            Console.WriteLine("모드 선택 0,1  기본 0");
            int.TryParse(Console.ReadLine() , out select);

            mode = select;
          
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
