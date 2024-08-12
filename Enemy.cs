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

    public class Enemy
    {
        public int posX, posY;
        private int maxHp;
        private int curHp;
        private double moveSpeed;
        private int dropGold;
  
        private EnemyMoveState moveState = EnemyMoveState.Down;

        public int curTick;

        public Enemy()
        {
            posX = 1; posY = 1;
            maxHp = 0;
            curHp = maxHp;
            moveSpeed = 0;
            dropGold = 0;

            curTick = 0;
        }

        public void EnemyInitStatus(int maxHp, double moveSpeed, int dropGold )
        {
            moveState = EnemyMoveState.Down;
            posX = Map.enemyPathPos; posY = Map.enemyPathPos;
           
            curTick = 0;

            this.maxHp = maxHp;
            this.curHp = maxHp;
            this.moveSpeed = moveSpeed;
            this.dropGold = dropGold;

        }

        public void MoveEnemy(object sender, System.Timers.ElapsedEventArgs e)
        {

            curTick++;
            if (curTick < moveSpeed)
            {
                return;
            }
            curTick = 0;
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
        public void GoDown()
        {
            posY++;

            if (posY == Map.heightEnemyPath)
            {
                moveState = EnemyMoveState.Right;
            }


        }
        public void GoRight()
        {
            posX++;
            if (posX == Map.widthEnemyPath)
            {
                moveState = EnemyMoveState.Up;
            }



        }

        public void GoUp()
        {
            posY--;
            if (posY == Map.enemyPathPos)
            {
                moveState = EnemyMoveState.Left;
            }

        }

        public void GoLeft()
        {
            posX--;
            if (posX == Map.enemyPathPos)
            {
                moveState = EnemyMoveState.Down;
            }

        }

        
    }
}
