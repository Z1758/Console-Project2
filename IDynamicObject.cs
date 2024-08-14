using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject2
{
    public interface IDynamicObject
    {
        public void Disable();
        public void MoveAction(object sender, System.Timers.ElapsedEventArgs e);
    }
}
