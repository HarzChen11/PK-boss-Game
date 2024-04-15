using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.PK_boss_
{
    class Boss: Game
    {
       
        public Boss(String Name)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            this.Name = Name;
            this.Att = random.Next(1, 6);
            this.Def = random.Next(1, 6);
            this.Agi = random.Next(1, 6);
        }
    }
}
