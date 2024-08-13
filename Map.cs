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
       
        

        public static int width = 15;
        public static int height = 15;

        const char userSpace = '■';
        const char border = '▣';
        const char randomEnemyPath = '▦';

        public static int userSpaceCnt = 0;
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

        public static List<Point> randomPath;

        static public void PixelMode1Init()
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
                        pixel[i, j] = userSpace;
                        pixelNum[i, j] = PixelType.USERSPACE;
                    }
                    //적 이동 경로 나눠 놓은것
                    else if (i == enemyPathPos && (enemyPathPos + 1 <= j && j <= widthEnemyPath))
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
                    else if (j == enemyPathPos && (enemyPathPos <= i && i <= heightEnemyPath - 1))
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

        static public void PixelMode2Init()
        {
            Random ran = new Random();
            
           
      

            for (int i = 0; i < height; i++)
            {

                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                    {
                        pixel[i, j] = border;
                        pixelNum[i, j] = PixelType.WALL;

                    }
                    else if (i % 2 == 0 || j % 2 == 0)
                    {
                        pixel[i, j] = userSpace;
                        pixelNum[i, j] = PixelType.RANDOMUSERSPACE;
                      
                    }
                    else
                    {
                        pixel[i, j] = randomEnemyPath;
                        pixelNum[i, j] = PixelType.RANDOMENEMYPATH;

                    }
                }
            }
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i % 2 == 0 || j % 2 == 0)
                        continue;
                    if (j == width - 2 && i == height - 2)
                        continue;

                    if (i == height - 2)
                    {
                        pixel[i, j + 1] = randomEnemyPath;
                        pixelNum[i, j + 1] = PixelType.RANDOMENEMYPATH;
                        
                        continue;
                    }

                    if (j == width - 2)
                    {
                        pixel[i +1, j] = randomEnemyPath;
                        pixelNum[i + 1, j] = PixelType.RANDOMENEMYPATH;
                        
                        continue;
                    }


                    if (ran.Next(0, 2) == 0)
                    {
                        pixel[i, j + 1] = randomEnemyPath;
                        pixelNum[i, j + 1] = PixelType.RANDOMENEMYPATH;
                       
                    }
                    else
                    {
                        pixel[i +1, j] = randomEnemyPath;
                        pixelNum[i + 1, j] = PixelType.RANDOMENEMYPATH;
                        
                    }
                  
                }
            }

            for (int i = 0; i < height; i++)
            {

                for (int j = 0; j < width; j++)
                {
                    if (pixelNum[i, j] == PixelType.RANDOMUSERSPACE)
                    {
                        userSpaceCnt++;

                    }
                    
                }
            }
            A_Star.PathFinding(pixelNum, new Point(1, 1), new Point(Map.height - 2, Map.width - 2), out randomPath);
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
                    pixel[i, j] = userSpace;


                    pixelNum[i, j] = PixelType.USERSPACE;
                }
            }
        }

        static public void DynamicRandomDraw()
        {
            foreach(Point point in randomPath)
            {
                pixel[point.y, point.x] = randomEnemyPath;
                pixelNum[point.y, point.x] = PixelType.RANDOMENEMYPATH;
            }

            for (int i = borderPos+1; i <= heightBorder-1; i++)
            {
                for (int j = borderPos+1; j <= widthBorder-1; j++)
                {
                    if (pixelNum[i,j] > PixelType.USERSPACE)
                    {
                        continue;
                    }
                    else
                    {
                        pixel[i, j] = userSpace;


                        pixelNum[i, j] = PixelType.RANDOMUSERSPACE;
                    }
               
                }
            }
        }

            static public void DrawPixel()
        {
       
          

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
           
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            for (int i = 0; i < width / 2; i++)
            {
                Console.Write(" ");
            }

            Console.WriteLine($"       남은 시간 {TimeManager.roundCount:00}");
            Console.WriteLine();
            Console.ResetColor();

            for (int i = 0; i < height; i++)
            {
                Console.Write("     ");
                for (int j = 0; j < width + 1; j++)
                {
                  
                    if (j >= width)
                    {
                        if(i == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($"   스테이지");
                            Console.Write($" {StageManager.currentStage}");
                        }
                        if (i == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($"   적 수");
                            Console.Write($" {StageManager.enemyCount:00}/{StageManager.enemyLimitCount}");


                        }
                        if (i == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($"   골드");
                            Console.Write($"  {StageManager.GetGold():0000}");

                        }

                        if (i == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"   S   ");
                            Console.Write($"♨ ㉿ ☎");
                        }
                        if (i == 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"   A   ");
                            Console.Write($"♣ ♬ ●");
                        }
                        if (i == 7)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"   B   ");
                            Console.Write($"♥ ★ ◈");
                        }
                        if (i == 8)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write($"   C   ");
                            Console.Write($"♡ ☆ ◇");
                        }




                        continue;
                    }
                    switch (pixelNum[i, j])
                    {
                        case PixelType.WALL:
                            //벽
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            break;
                        case PixelType.USERSPACE:
                            //플레이어 공간
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case PixelType.ENEMYPATH:
                            //적 이동 경로
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            break;
                        case PixelType.RANDOMUSERSPACE:
                            //플레이어 공간
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case PixelType.RANDOMENEMYPATH:
                            //적 이동 경로
                            Console.ForegroundColor = ConsoleColor.Black;
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


                    if (pixelNum[i, j] == PixelType.BOSS)
                    {
                        //보스
                        Console.ForegroundColor = CheckHp(i, j);
                        pixel[i, j] = 'B';
                        Console.Write(pixel[i, j]);
                        Console.Write(1);
                       

                    }
                    else if (10 + PixelType.ENEMY + 1 > pixelNum[i, j] && pixelNum[i, j] >= PixelType.ENEMIES)
                    {
                        //겹쳐있는 적
                        Console.ForegroundColor = CheckHp(i, j);
                        pixel[i, j] = 'E';
                        Console.Write(pixel[i, j]);


                    
                        Console.Write(pixelNum[i, j]- PixelType.ENEMY +1  );


                    }
                    else if(pixelNum[i, j] == PixelType.ENEMY){
                        //적
                      
                        Console.ForegroundColor = CheckHp(i, j);
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
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for (int i = 0; i < width/2; i++)
            {
                Console.Write(" ");
            }

            Console.WriteLine("   Q 뽑기 E 병합 T 판매");
        }
        static public ConsoleColor CheckHp(int y, int x)
        {
            Console.ResetColor();
            for (int i = 0; i < RandomTowerDefense.gameManager.activeEnemies.Count; i++)
            {
                if (RandomTowerDefense.gameManager.activeEnemies[i].PosX == x && RandomTowerDefense.gameManager.activeEnemies[i].PosY == y)
                {
                    if (RandomTowerDefense.gameManager.activeEnemies[i].CurHp < RandomTowerDefense.gameManager.activeEnemies[i].MaxHp * 0.3)
                    {
                        return ConsoleColor.Red;
                    }
                    else if (RandomTowerDefense.gameManager.activeEnemies[i].CurHp < RandomTowerDefense.gameManager.activeEnemies[i].MaxHp * 0.7)
                    {
                        return ConsoleColor.Yellow;
                    }
                    else
                    {

                        return ConsoleColor.Green;
                    }
                }
               
            }
           
            return ConsoleColor.Gray;
        }
    }

   
}
