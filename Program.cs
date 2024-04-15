using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.PK_boss_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Player player = new Player("玩家");
            Boss boss = null;

            for (int i = 1; i <= 10; i++)
            {
                boss = creatBoss(i, boss);

                if (i > 5)
                {
                   int round = player.Buff();
                    if (round != 0)
                    {
                        i = round;
                    }
                }

                player.PK(boss);
                Console.WriteLine($"第{i}關結束");

                if (player.Hp <= 0)
                {
                    break;
                }
            }

            Console.WriteLine("遊戲結束");
            Console.ReadKey();
        }

        public static Boss creatBoss(int stage, Boss boss)
        {
            if (stage > 5)
            {
                boss.Hp = 10;
                boss.Name = $"第{stage}個魔王";

                //boss.Att = (boss.Att >= boss.Agi) && (boss.Att >= boss.Def) ? boss.Att : boss.Att + 1;
                if ((boss.Att >= boss.Agi) && (boss.Att >= boss.Def))
                    boss.Att += 1;
                else if ((boss.Agi >= boss.Att) && (boss.Agi >= boss.Def))
                    boss.Agi += 1;
                else if ((boss.Def >= boss.Att) && (boss.Def >= boss.Agi))
                    boss.Def += 1;

                if ((boss.Att <= boss.Agi) && (boss.Att <= boss.Def))
                    boss.Att -= 1;
                else if ((boss.Agi <= boss.Att) && (boss.Agi <= boss.Def))
                    boss.Agi -= 1;
                else if ((boss.Def <= boss.Att) && (boss.Def <= boss.Agi))
                    boss.Def -= 1;

                return boss;
            }
            else
            {
                return new Boss($"第{stage}個魔王");
            }
        }


    }
}
