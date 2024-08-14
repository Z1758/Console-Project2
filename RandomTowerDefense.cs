using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;

namespace ConsoleProject2
{
    public class RandomTowerDefense
    {

        public static GameManager gameManager;

        public static int mode;

        public static bool clearFlag =false;

        static public void Init()
        {

            

            StageManager.StageManagerInit();

            Player player = Player.Instance();

            gameManager = GameManager.Instance();
            gameManager.SetPlayer(player);
            gameManager.CurrentEnemyInfoSet();

            TimeManager.TimerInit();
        }
      
        static public void Drawing()
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

        }

        static public void Update()
        {
            Drawing();
            gameManager.InputKey();

           
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



            while (true)
            {
                Update();
                if (EndGameCheck()==false)
                {
                    EndGame();

                    if (SelectReStart() ==false)
                    {
                        break;
                    }
                    ReStartInit();
                    clearFlag = false;
                }

                
            }
           

        }

        static void ReStartInit()
        {
            switch (mode)
            {
                case 0:
                    Map.PixelMode1Init();
                    break;
                case 1:
                    Map.PixelMode2Init();
                    break;

            }
            StageManager.StageManagerInit();
            gameManager.ReStart();
            TimeManager.TimerInit();


        }

        static public bool EndGameCheck()
        {
            if (clearFlag)
            {
                return false;
            }

            if (StageManager.gameoverCount <= 0|| StageManager.currentStage > 10)
            {
              
                return false;

            }

            return true;
        }

        static public void EndGame(){
            TimeManager.EndTimer();
            Drawing();
            
            Thread.Sleep(1000);
            if (mode == 0)
            {
                GamaOver.OutPutGameOver(StageManager.gameoverCount == StageManager.enemyLimitCount);
            }

            else if (mode == 1)
            {

                GamaOver.OutPutGameOver(StageManager.gameoverCount > 0);
            }
        }


      

        static public void SelectMode()
        {
            ClearBuffer();
            int select = 0;
            Console.WriteLine("             맵 선택");
            Console.WriteLine(  "0. 클래식 맵(디폴트)     1. 랜덤 맵");
            int.TryParse(Console.ReadLine() , out select);

            mode = select;
            ClearBuffer();
            Console.Clear();
        }
        static public bool SelectReStart()
        {
            ClearBuffer();
            int rSelect =' ';

            int.TryParse(Console.ReadLine(), out rSelect);

            if(rSelect == 1)
            {
                Console.Clear();
                return true;
            }
            else
            {
                Console.Clear();
                return false;
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
