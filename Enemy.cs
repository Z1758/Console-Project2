using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
    public enum EnemyMoveState 
    {
        Down, Right, Up, Left, END
    }

    public class Enemy : IDynamicObject
    {
        private int posY;
        private int maxHp;
        private int curHp;
        private double moveSpeed;
        private int dropGold;
  
        private EnemyMoveState moveState = EnemyMoveState.Down;

        public int moveTick;
        private int posX;

        public int CurHp { get => curHp;  }
        public int PosX { get => posX;  }
        public int PosY { get => posY;  }

        public event Action<Enemy> DisableEvent;

        public Enemy()
        {
            posX = 1; posY = 1;
            maxHp = 0;
            curHp = maxHp;
            moveSpeed = 0;
            dropGold = 0;

            moveTick = 0;
        }

        public void EnemyInitStatus(int maxHp, double moveSpeed, int dropGold )
        {
            moveState = EnemyMoveState.Down;
            posX = Map.enemyPathPos; posY = Map.enemyPathPos;

            moveTick = 0;

            this.maxHp = maxHp;
            curHp = maxHp;
            this.moveSpeed = moveSpeed;
            this.dropGold = dropGold;

        }

        public void MoveEnemy(object sender, System.Timers.ElapsedEventArgs e)
        {

            moveTick++;

            //테스트용 임시
          
           // TakeDamage();
            

            if (moveTick < moveSpeed)
            {
                return;
            }
            moveTick = 0;
            switch (moveState)
            {
                case EnemyMoveState.Down:
                    GoDown();
                    break;
                case EnemyMoveState.Right:
                    GoRight();
                    break;
                case EnemyMoveState.Up:
                    GoUp();
                    break;
                case EnemyMoveState.Left:
                    GoLeft();
                    break;


            }
      
        }

        public void TakeDamage(int atk)
        {
            if (CurHp <= 0)
            {
                return;
            }
            curHp -= atk;
   
            if (CurHp <= 0)
            {
                Disable();
            }
        }


        public void Disable()
        {
            DisableEvent(this);
        }
   
        public void GoDown()
        {
            posY++;

            if (PosY == Map.heightEnemyPath)
            {
                moveState = EnemyMoveState.Right;
            }


        }
        public void GoRight()
        {
            posX++;
            if (PosX == Map.widthEnemyPath)
            {
                moveState = EnemyMoveState.Up;
            }



        }

        public void GoUp()
        {
            posY--;
            if (PosY == Map.enemyPathPos)
            {
                moveState = EnemyMoveState.Left;
            }

        }

        public void GoLeft()
        {
            posX--;
            if (PosX == Map.enemyPathPos)
            {
                moveState = EnemyMoveState.Down;
            }

        }

      
    }
}
