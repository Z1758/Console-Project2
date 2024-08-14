using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleProject2
{
    public class Tower : IDynamicObject
    {
        private int posX, posY;
        private int attack;
        private int atkSpeed;
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
        public int AtkSpeed { get => atkSpeed; set => atkSpeed = value; }

        public event Action<Tower> AttackEvent;
        public event Action<Tower> DisableEvent;

        public Tower()
        {
            posX = 0; posY =0 ;
            attack = 0;
            type = 'M';
            AtkSpeed = 0;
            grade = 0;

            AtkTick = 0;
        }

        public void TowerInitStatus(int posX, int posY)
        {
           
            this.posX = posX; this.posY = posY;
            AtkTick = AtkSpeed;

        }

        public void RandomInit(int ran)
        {
            switch (ran)
            {
                case PixelType.GRADE_C_POWER:
                    {
                        attack = 30;
                        AtkSpeed = 10;
                        range = 3;
                        type = '♡';
                        grade = PixelType.GRADE_C; 
                    }
                    break;
                case PixelType.GRADE_C_SPEED:
                    {
                        attack = 20;
                        AtkSpeed = 8;
                        range = 3;
                        type = '☆';
                        grade = PixelType.GRADE_C;
                    }
                    break;
                case PixelType.GRADE_C_RANGE:
                    {
                        attack = 20;
                        AtkSpeed = 10;
                        range = 4;
                        type = '◇';
                        grade = PixelType.GRADE_C;
                    }
                    break;


                case PixelType.GRADE_B_POWER:
                    {
                        attack = 50;
                        AtkSpeed = 9;
                        range = 4;
                        type = '♥';
                        grade = PixelType.GRADE_B;
                    }
                    break;
                case PixelType.GRADE_B_SPEED:
                    {
                        attack = 30;
                        AtkSpeed = 7;
                        range = 4;
                        type = '★';
                        grade = PixelType.GRADE_B;
                    }
                    break;
                case PixelType.GRADE_B_RANGE:
                    {
                        attack = 30;
                        AtkSpeed = 9;
                        range = 5;
                        type = '◈';
                        grade = PixelType.GRADE_B;
                    }
                    break;



                case PixelType.GRADE_A_POWER:
                    {
                        attack = 110;
                        AtkSpeed = 8;
                        range = 5;
                        type = '♣';
                        grade = PixelType.GRADE_A;
                    }
                    break;
                case PixelType.GRADE_A_SPEED:
                    {
                        attack = 60;
                        AtkSpeed = 5;
                        range = 5;
                        type = '♬';
                        grade = PixelType.GRADE_A;
                    }
                    break;
                case PixelType.GRADE_A_RANGE:
                    {
                        attack = 80;
                        AtkSpeed = 8;
                        range = 6;
                        type = '●';
                        grade = PixelType.GRADE_A;
                    }
                    break;



                case PixelType.GRADE_S_POWER:
                    {
                        attack = 180;
                        AtkSpeed = 7;
                        range = 6;
                        type = '♨';
                        grade = PixelType.GRADE_S;
                    }
                    break;
                case PixelType.GRADE_S_SPEED:
                    {
                        attack = 80;
                        AtkSpeed = 3;
                        range = 6;
                        type = '㉿';
                        grade = PixelType.GRADE_S;
                    }
                    break;
                case PixelType.GRADE_S_RANGE:
                    {
                        attack = 120;
                        AtkSpeed = 7;
                        range = 8;
                        type = '☎';
                        grade = PixelType.GRADE_S;
                    }
                    break;

            }
        }


        public void MoveAction(object sender, ElapsedEventArgs e)
        {
            AtkTick++;




            if (AtkTick < AtkSpeed)
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
