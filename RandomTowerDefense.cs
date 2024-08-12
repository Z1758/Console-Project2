﻿using System;
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
            Console.WriteLine(gameManager.output);
           // ClearBuffer();
        }
        static void Main(string[] args)
        {
            
            
            Init();





            

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
