using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
    public interface InputManager
    {
        void InputKey();
        void MoveCursor(int x, int y);
        void GachaTower();
        void SellTower();

        void MergeTower();
    }
}
