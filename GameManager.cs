using System.Diagnostics;

namespace ConsoleProject2
{

    public class GameManager : InputManager
    {

        Player player;

        public int enemyCount;

        static public int enemyLimitCount;
        static public int enemySetOneStage;


        public EnemyInfo curEnemyInfo;

        Queue<Enemy> disabledEnemyQueue = new Queue<Enemy>();

        List<Enemy> activeEnemies = new List<Enemy>();

        Queue<Tower> disabledTowerQueue = new Queue<Tower>();

        List<Tower> activeTowers = new List<Tower>();

        private GameManager()
        {
           
            enemyLimitCount = 80;
            enemySetOneStage = 5;
            enemyCount = 0;
            InitObj();
            TimeManager.RoundEvent += SetEnemyStagePerSecond;
         
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public void SetEnemyStagePerSecond()
        {
            if (enemyCount < enemySetOneStage)
            {
                SetEnemy();
            }
        }

        public void CheckEnemy()
        {
            for (int i = 0; i < activeEnemies.Count; i++)
            {
                if (Map.pixelNum[activeEnemies[i].PosY, activeEnemies[i].PosX] >= PixelType.ENEMIES)
                {
                    Map.pixelNum[activeEnemies[i].PosY, activeEnemies[i].PosX]++;
                }
                else if (Map.pixelNum[activeEnemies[i].PosY, activeEnemies[i].PosX] == PixelType.ENEMY)
                {

                    Map.pixelNum[activeEnemies[i].PosY, activeEnemies[i].PosX] = PixelType.ENEMIES;
                }
                else
                {
                    Map.pixelNum[activeEnemies[i].PosY, activeEnemies[i].PosX] = PixelType.ENEMY;
                }

            }
        }
        public void CheckTower()
        {
            for (int i = 0; i < activeTowers.Count; i++)
            {
                Map.pixelNum[activeTowers[i].PosY, activeTowers[i].PosX] = activeTowers[i].Grade;
                Map.pixel[activeTowers[i].PosY, activeTowers[i].PosX] = activeTowers[i].Type;

            }
        }

        public bool CheckTowerCursor()
        {
            bool check = false;
            for (int i = 0; i < activeTowers.Count; i++)
            {
                if (activeTowers[i].PosX == player.PosX && activeTowers[i].PosY == player.PosY)
                {
                    check = true;
                    break;
                }

            }
            return check;
        }

       


        public void ChechkPlayer()
        {
            Map.pixelNum[player.PosY, player.PosX] = PixelType.PLAYER;
        }
        
        
        public void CheckDraw()
        {
            CheckEnemy();
            CheckTower();
            ChechkPlayer();
        }

        public void AttackCollider(Tower tower)
        {
            if(enemyCount == 0)
            {
                return;
            }
           
            
            //타워의 범위부터 계산
            /*
            for(int i = tower.PosY - tower.Range ; i < tower.PosY+ tower.Range ; i++)
            {
                for (int j = tower.PosX - tower.Range  ; j <  tower.PosX+ tower.Range; j++)
                {
                    if (i == Map.enemyPathPos && (Map.enemyPathPos <= j && j <= Map.widthEnemyPath) ||
                             j == Map.widthEnemyPath && (Map.enemyPathPos + 1 <= i && i <= Map.heightEnemyPath) ||
                             i == Map.heightEnemyPath && (Map.enemyPathPos <= j && j <= Map.widthEnemyPath - 1) ||
                             j == Map.enemyPathPos && (Map.enemyPathPos + 1 <= i && i <= Map.heightEnemyPath - 1))
                    {

                        for (int e = 0; e < activeEnemies.Count; e++)
                        {
                            if (activeEnemies[e] != null)
                            {
                                if (activeEnemies[e].posY == i && activeEnemies[e].posX == j)
                                {
                                    if (activeEnemies[e].CurHp <= 0)
                                    {
                                        continue;
                                    }

                                    activeEnemies[e].TakeDamage(tower.Attack);
                                    tower.AtkTick = 0;

                                 

                                    return;
                                }

                            }


                        }
                    }
                }
            }
            */
            
            // 제일 먼저 나온적부터 공격
            for (int e = 0; e < activeEnemies.Count; e++)
            {
                if (activeEnemies[e] != null)
                {
                    for (int i = tower.PosY - tower.Range; i < tower.PosY + tower.Range; i++)
                    {
                        for (int j = tower.PosX - tower.Range; j < tower.PosX + tower.Range; j++)
                        {
                            if (i == Map.enemyPathPos && (Map.enemyPathPos <= j && j <= Map.widthEnemyPath) ||
                                     j == Map.widthEnemyPath && (Map.enemyPathPos + 1 <= i && i <= Map.heightEnemyPath) ||
                                     i == Map.heightEnemyPath && (Map.enemyPathPos <= j && j <= Map.widthEnemyPath - 1) ||
                                     j == Map.enemyPathPos && (Map.enemyPathPos + 1 <= i && i <= Map.heightEnemyPath - 1))
                            {
                                if (activeEnemies[e].PosY == i && activeEnemies[e].PosX == j)
                                {
                                    if (activeEnemies[e].CurHp <= 0)
                                    {
                                        continue;
                                    }

                                    activeEnemies[e].TakeDamage(tower.Attack);
                                    tower.AtkTick = 0;

                              

                                    return;
                                }

                            }
                        }
                    }

                }


            }
           



        }

        public bool SetTower()
        {
            
            if (disabledTowerQueue.Count <= 0)
            {
                return false;
            }

         

            Random random = new Random();

            Tower tower = disabledTowerQueue.Dequeue();
            tower.AttackEvent += AttackCollider;

            tower.RandomInit(random.Next(PixelType.GRADE_C_START, PixelType.GRADE_C_END));
            
     
            tower.TowerInitStatus(player.PosX, player.PosY);



            tower.DisableEvent += DisableTower;
            TimeManager.AddTowerAttackEvent(tower);

            activeTowers.Add(tower);

            return true;
        }

        public void DisableTower(Tower tower )
        {
            tower.DisableEvent -= DisableTower;
            TimeManager.RemoveTowerAttackEvent(tower);
            activeTowers.Remove(tower);
            disabledTowerQueue.Enqueue(tower);
        }
      
        public void SetEnemy()
        {
            if (disabledEnemyQueue.Count <= 0)
            {
                return;
            }
            Enemy enemy = disabledEnemyQueue.Dequeue();
            enemy.EnemyInitStatus(curEnemyInfo.hp, curEnemyInfo.moveSpeed, curEnemyInfo.dropGold);

            enemy.DisableEvent += DisableEnemy;
            TimeManager.AddEnemyMoveEvent(enemy);

            activeEnemies.Add(enemy);
            enemyCount++;


            //임시 나중에 수정
            //curEnemyInfo = StageManager.EnemyInformations[enemyCount];
        }
        public void DisableEnemy(Enemy enemy)
        {
            enemy.DisableEvent -= DisableEnemy;
            TimeManager.RemoveEnemyMoveEvent(enemy);

            activeEnemies.Remove(enemy);

            disabledEnemyQueue.Enqueue(enemy);

            enemyCount--;
        }



        public void InitObj()
        {
            for (int i = 0; i < enemyLimitCount; i++)
            {
                disabledEnemyQueue.Enqueue(new Enemy());
            }

            for (int i = 0; i < (Map.widthCenter-2) * (Map.heightCenter-2) ; i++)
            {
                disabledTowerQueue.Enqueue(new Tower());
            }
        }


        public void CurrentEnemyInfoSet()
        {
            //임시 나중에 수정
            curEnemyInfo = StageManager.EnemyInformations[1];
        }


        private static GameManager gmSingleton;
        public static GameManager Instance()
        {
            if (gmSingleton == null)
            {
                gmSingleton = new GameManager();
                

            }

            return gmSingleton;

        }

        public void InputKey()
        {
           
            //매끄러운 키 입력 구현
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);

                switch (consoleKey.Key)
                {
                    case ConsoleKey.RightArrow:
                        MoveCursor(1,0);
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveCursor(-1,0);

                        break;

                    case ConsoleKey.UpArrow:
                        MoveCursor(0,-1);

                        break;
                    case ConsoleKey.DownArrow:
                        MoveCursor(0,1);
                        break;
                    case ConsoleKey.Q:
                        GachaTower();
                        break;
                    case ConsoleKey.E:
                        MergeTower();
                        break;
                    case ConsoleKey.T:
                        SellTower();
                        break;
                     default:
                        
                        break;
                }
            }
        }

        public void MoveCursor(int posX, int posY)
        {
            if (player.PosX + posX < Map.centerPos || player.PosX + posX > Map.widthCenter)
                return;
            if (player.PosY + posY < Map.centerPos || player.PosY + posY > Map.heightCenter)
                return;

            player.PosX += posX;
            player.PosY += posY;


        }

        public void GachaTower()
        {
            if(StageManager.GetGold() >= 50)
            {
                if (CheckTowerCursor() == false)
                {
                    SetTower();
                    StageManager.SetGold(-50);
                }
            }
        }

        public void SellTower()
        {
            for (int i = 0; i < activeTowers.Count; i++)
            {
                if (activeTowers[i].PosX == player.PosX && activeTowers[i].PosY == player.PosY)
                {
                    activeTowers[i].Disable();
                    StageManager.SetGold(40);
                    break;
                }

            }
        }

        public void MergeTower()
        {
            char type = 'N';
            Tower[] towerIndex = new Tower[3];
            for (int i = 0; i < activeTowers.Count; i++)
            {
                if (activeTowers[i].PosX == player.PosX && activeTowers[i].PosY == player.PosY)
                {
                    type = activeTowers[i].Type;
                    towerIndex[0] = activeTowers[i];
                    break;
                }

            }
            if (type == 'N')
                return;

            
           
            int cnt = 1;
            for (int i = 0; i < activeTowers.Count; i++)
            {
                if (activeTowers[i].Type == type)
                {
                    if (towerIndex[0] == activeTowers[i])
                    {
                        continue;
                    }

                    towerIndex[cnt] = activeTowers[i];
                    cnt++;

                    if (cnt == 3)
                    {
                        break;
                    }
                }

            }
           
            if (cnt ==3)
            {
                for (int i = 0; i < cnt; i++)
                {
                    
                        towerIndex[i].Disable();
                    
                }
                //등급 강화 추가 예정
                SetTower();


            }
          


        }
    }
}
