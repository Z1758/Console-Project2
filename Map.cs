using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{



    static public class Map
    {
       
        

        public static int width = 12;
        public static int height = 12;

        const char center = '■';
        const char border = '▣';


        // 외부 
        static int borderPos = 0;
        static int widthBorder = width - 1;
        static int heightBorder = height - 1;

        // 적 이동 경로
       public static int enemyPathPos = 1;
       public static int widthEnemyPath = width - 2;
       public static int heightEnemyPath = height - 2;

        // 내부
        static int borderInPos = 2;
        static int widthBorderIn = width - 3;
        static int heightBorderIn = height - 3;

        // 중앙
       public static int centerPos = 3;
       public static int widthCenter = width - 4;
       public static int heightCenter = height - 4;


        //픽셀 입력용
        public static char[,] pixel = new char[height, width];
        //픽셀 색 구분용
        public static int[,] pixelNum = new int[height, width];



        static public void PixelInit()
        {

            for (int i = 0; i < height; i++)
            {

                for (int j = 0; j < width; j++)
                {
                    if (i == borderPos || i == heightBorder || j == borderPos || j == widthBorder)
                    {
                        pixel[i, j] = border;
                        pixelNum[i, j] = PixelType.WALL;
                    }
                    else if ((i == borderInPos || i == heightBorderIn) && (j >= borderInPos && j <= widthBorderIn))
                    {
                        pixel[i, j] = border;
                        pixelNum[i, j] = PixelType.WALL;
                    }
                    else if ((i >= borderInPos && i <= heightBorderIn) && (j == borderInPos || j == widthBorderIn))
                    {
                        pixel[i, j] = border;
                        pixelNum[i, j] = PixelType.WALL;
                    }

                    else if ((i >= centerPos && i <= heightCenter) && (j >= centerPos && j <= widthCenter))
                    {
                        pixel[i, j] = center;
                        pixelNum[i, j] = PixelType.USERSPACE; 
                    }
                    //적 이동 경로 나눠 놓은것
                    else if (i == enemyPathPos && (enemyPathPos + 1<= j && j <= widthEnemyPath))
                    {
                        pixel[i, j] = '←';
                        pixelNum[i, j] = PixelType.ENEMYPATH;


                    }
                    else if (j == widthEnemyPath && (enemyPathPos + 1 <= i && i <= heightEnemyPath))
                    {
                        pixel[i, j] = '↑';
                        pixelNum[i, j] = PixelType.ENEMYPATH;


                    }
                    else if (i == heightEnemyPath && (enemyPathPos <= j && j <= widthEnemyPath - 1))
                    {
                        pixel[i, j] = '→';
                        pixelNum[i, j] = PixelType.ENEMYPATH;


                    }
                    else if (j == enemyPathPos && (enemyPathPos  <= i && i <= heightEnemyPath - 1))
                    {
                        pixel[i, j] = '↓';
                        pixelNum[i, j] = PixelType.ENEMYPATH;


                    }
                    // 적 이동 경로 합친거
                    /*
                    else if (i == enemyPathPos && (enemyPathPos <= j && j <= widthEnemyPath) ||
                             j == widthEnemyPath && (enemyPathPos + 1 <= i && i <= heightEnemyPath) ||
                             i == heightEnemyPath && (enemyPathPos <= j && j <= widthEnemyPath - 1) ||
                             j == enemyPathPos && (enemyPathPos + 1 <= i && i <= heightEnemyPath - 1))
                    {
                        pixel[i, j] = '↑';
                        pixelNum[i, j] = PixelType.ENEMYPATH;
                    }*/

                    else
                    {
                        pixel[i, j] = '※';
                        pixelNum[i, j] = PixelType.END;

                    }

                }

            }


        }


        static public void DynamicDraw()
        {

            for (int i = enemyPathPos; i <= widthEnemyPath; i++)
            {
                pixel[enemyPathPos, i] = '←';


                pixelNum[enemyPathPos, i] = PixelType.ENEMYPATH;
            }


            for (int i = enemyPathPos + 1; i <= heightEnemyPath; i++)
            {
                pixel[i, widthEnemyPath] = '↑';

                pixelNum[i, widthEnemyPath] = PixelType.ENEMYPATH;
            }


            for (int i = widthEnemyPath - 1; i >= enemyPathPos; i--)
            {
                pixel[heightEnemyPath, i] = '→';

                pixelNum[heightEnemyPath, i] = PixelType.ENEMYPATH;
            }

            for (int i = heightEnemyPath - 1; i >= enemyPathPos; i--)
            {
                pixel[i, enemyPathPos] = '↓';


                pixelNum[i, enemyPathPos] = PixelType.ENEMYPATH;
            }

            for(int i = centerPos ; i <= heightCenter; i++)
            {
                for (int j = centerPos ; j <= widthCenter; j++)
                {
                    pixel[i, j] = center;


                    pixelNum[i, j] = PixelType.USERSPACE;
                }
            }
        }





        static public void DrawPixel()
        {
       
          

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine($"           라운드 시간 {TimeManager.roundCount}");
            Console.ResetColor();

            for (int i = 0; i < height; i++)
            {
                Console.Write("     ");
                for (int j = 0; j < width + 1; j++)
                {
                  
                    if (j >= width)
                    {
                        if (i == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("    여기");
                        }

                        continue;
                    }
                    switch (pixelNum[i, j])
                    {
                        case PixelType.WALL:
                            //벽
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case PixelType.USERSPACE:
                            //플레이어 공간
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case PixelType.ENEMYPATH:
                            //적 이동 경로
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            break;
                        case PixelType.GRADE_C:
                            //타워 등급
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        case PixelType.GRADE_B:
                            //타워 등급
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case PixelType.GRADE_A:
                            //타워 등급
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case PixelType.GRADE_S:
                            //타워 등급
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case PixelType.PLAYER:
                            //유저 위치
                            
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }

                  

                    if (10 + PixelType.ENEMY + 1 > pixelNum[i, j] && pixelNum[i, j] >= PixelType.ENEMIES)
                    {
                        //겹쳐있는 적
                        Console.ForegroundColor = ConsoleColor.Green;
                        pixel[i, j] = 'E';
                        Console.Write(pixel[i, j]);

                        

                        Console.Write(pixelNum[i, j]- PixelType.ENEMY +1  );


                    }
                    else if(pixelNum[i, j] == PixelType.ENEMY){
                        //적
                        Console.ForegroundColor = ConsoleColor.Green;
                        pixel[i, j] = 'E';
                        Console.Write(pixel[i, j]);
                        Console.Write(1);
                        

                    }
                  
                    else
                    {
                        Console.Write(pixel[i, j]);
                    }

                   
                    Console.ResetColor();


                }
                Console.ResetColor();
                Console.WriteLine();
            }


        }

    }
}
