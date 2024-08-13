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
                        attack = 3000;
                        atkSpeed = 10;
                        range = 3;
                        type = '♡';
                        grade = PixelType.GRADE_C; 
                    }
                    break;
                case PixelType.GRADE_C_SPEED:
                    {
                        attack = 2000;
                        atkSpeed = 8;
                        range = 3;
                        type = '☆';
                        grade = PixelType.GRADE_C;
                    }
                    break;
                case PixelType.GRADE_C_RANGE:
                    {
                        attack = 2000;
                        atkSpeed = 10;
                        range = 4;
                        type = '◇';
                        grade = PixelType.GRADE_C;
                    }
                    break;


                case PixelType.GRADE_B_POWER:
                    {
                        attack = 50;
                        atkSpeed = 9;
                        range = 4;
                        type = '♥';
                        grade = PixelType.GRADE_B;
                    }
                    break;
                case PixelType.GRADE_B_SPEED:
                    {
                        attack = 30;
                        atkSpeed = 7;
                        range = 4;
                        type = '★';
                        grade = PixelType.GRADE_B;
                    }
                    break;
                case PixelType.GRADE_B_RANGE:
                    {
                        attack = 30;
                        atkSpeed = 9;
                        range = 5;
                        type = '◈';
                        grade = PixelType.GRADE_B;
                    }
                    break;



                case PixelType.GRADE_A_POWER:
                    {
                        attack = 110;
                        atkSpeed = 8;
                        range = 5;
                        type = '♣';
                        grade = PixelType.GRADE_A;
                    }
                    break;
                case PixelType.GRADE_A_SPEED:
                    {
                        attack = 60;
                        atkSpeed = 5;
                        range = 5;
                        type = '♬';
                        grade = PixelType.GRADE_A;
                    }
                    break;
                case PixelType.GRADE_A_RANGE:
                    {
                        attack = 80;
                        atkSpeed = 8;
                        range = 6;
                        type = '●';
                        grade = PixelType.GRADE_A;
                    }
                    break;



                case PixelType.GRADE_S_POWER:
                    {
                        attack = 180;
                        atkSpeed = 7;
                        range = 6;
                        type = '♨';
                        grade = PixelType.GRADE_S;
                    }
                    break;
                case PixelType.GRADE_S_SPEED:
                    {
                        attack = 80;
                        atkSpeed = 3;
                        range = 6;
                        type = '㉿';
                        grade = PixelType.GRADE_S;
                    }
                    break;
                case PixelType.GRADE_S_RANGE:
                    {
                        attack = 120;
                        atkSpeed = 7;
                        range = 8;
                        type = '☎';
                        grade = PixelType.GRADE_S;
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
