using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
     public struct EnemyInfo
    {
     
        public int hp;
        public double moveSpeed;
        public int dropGold;
    }
   



    static public class StageManager
    {
        public static Dictionary<int,EnemyInfo> EnemyInformations;

  

        static public void StageManagerInit()
        {
            EnemyInformations = new Dictionary<int, EnemyInfo>();
            SetEnemyInformation();
        }

        static public void SetEnemyInformation()
        {
            EnemyInformations.Add(1, new EnemyInfo { hp = 10,  moveSpeed = 10, dropGold = 10 });
            EnemyInformations.Add(2, new EnemyInfo { hp = 15, moveSpeed = 9, dropGold = 10 });
            EnemyInformations.Add(3, new EnemyInfo { hp = 10, moveSpeed = 3, dropGold = 10 });
            EnemyInformations.Add(4, new EnemyInfo { hp = 50, moveSpeed = 20, dropGold = 10 });
            EnemyInformations.Add(5, new EnemyInfo { hp = 40, moveSpeed = 10, dropGold = 10 });
          
        }

      
    }
}
