using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
    public class Tower : IDynamicObject
    {
        private int posX, posY;
        private int attack;
        private double atkSpeed;
        private int range;
        private char type;
        private int grade;
        private int atkTick;
        

        public int Range { get => range;  }

        public int PosX { get => posX; }
        public int PosY { get => posY;  }
        public int Attack { get => attack; }
        public int AtkTick { get => atkTick; set => atkTick = value; }
        public char Type { get => type;  }
        public int Grade { get => grade; }

        public event Action<Tower> AttackEvent;
        public event Action<Tower> DisableEvent;

        public Tower()
        {
            posX = 0; posY =0 ;
            attack = 0;
            type = 'M';
            atkSpeed = 0;
            grade = 0;

            AtkTick = 0;
        }

        public void TowerInitStatus(int posX, int posY)
        {
           
            this.posX = posX; this.posY = posY;
            AtkTick = 0;

        }

        public void RandomInit(int ran)
        {
            switch (ran)
            {
                case PixelType.GRADE_C_POWER:
                    {
                        attack = 20;
                        atkSpeed = 3;
                        range = 3;
                        type = '♡';
                        grade = PixelType.GRADE_C; //중복 코드 나중에 수정
                    }
                    break;
                case PixelType.GRADE_C_SPEED:
                    {
                        attack = 20;
                        atkSpeed = 3;
                        range = 3;
                        type = '☆';
                        grade = PixelType.GRADE_B;// 중복 코드 나중에 수정
                    }
                    break;
                case PixelType.GRADE_C_RANGE:
                    {
                        attack = 20;
                        atkSpeed = 3;
                        range = 3;
                        type = '◇';
                        grade = PixelType.GRADE_A;// 중복 코드 나중에 수정
                    }
                    break;

            }
        }

        public void AttackTower(object sender, System.Timers.ElapsedEventArgs e)
        {

            AtkTick++;

           


            if (AtkTick < atkSpeed)
            {
                return;
            }
           
            AttackEvent(this);

        }

        public void Disable()
        {
            DisableEvent(this);
        }
    }
}
