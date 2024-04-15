using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6.PK_boss_
{
    internal class Player : Game
    {
        private bool item1 = true;
        private bool item2 = true;
        private bool item3 = true;
        private bool item4 = false;

        public Player(String Name)
        {
            this.Name = Name;
            this.Att = 5;
            this.Def = 5;
            this.Agi = 5;
        }

        private void Attack(Game player, Game boss)
        {
            int atk = player.Att - boss.Def > 0 ? player.Att - boss.Def : 1;
            boss.Hp -= atk;

            Console.WriteLine($"{player.Name}對{boss.Name}造成{atk}傷害");
            //Console.WriteLine($"目前{player.Name}血量為{player.Hp}，{boss.Name}血量為{boss.Hp}");

            if (boss.Hp <= 0)
                return;

            if(Avoid(player, boss))
            {
                Console.WriteLine("成功閃避攻擊!!!!");
            }
            else
            {
                atk = boss.Att - player.Def > 0 ? boss.Att - player.Def : 1;

                if (player.Hp - atk <= 0)
                {
                    Console.WriteLine("玩家已死亡，血量為:" + (atk - player.Hp));
                    if (item4)
                    {
                        player.Hp = atk - player.Hp + 5;
                        Console.WriteLine("使用復活藥水，玩家血量為:" + player.Hp);
                    }

                }
                else
                {
                    player.Hp -= atk;
                }

                Console.WriteLine($"{boss.Name}對{player.Name}造成{atk}傷害");
                Console.WriteLine($"目前{player.Name}血量為{player.Hp}，{boss.Name}血量為{boss.Hp}");
            }

            
        }

        public void PK(Boss boss)
        {

            Console.WriteLine("==================戰鬥開始==================");
            Console.WriteLine(this.Name + $"HP:{this.Hp},Att:{this.Att},Def:{this.Def},Agi:{this.Agi}");
            Console.WriteLine(boss.Name + $"HP:{boss.Hp},Att:{boss.Att},Def:{boss.Def},Agi:{boss.Agi}");
            Console.WriteLine("===========================================");


            while (this.Hp > 0 && boss.Hp > 0)
            {
                if (this.Agi > boss.Agi)
                {
                    this.Attack(this, boss);
                }
                else
                {
                    this.Attack(boss, this); ;
                }
            }

            if (this.Hp > 0)
            {
                Console.WriteLine(this.Name + "獲勝");
                this.Hp = 10;
            }
            else
            {
                Console.WriteLine(boss.Name + "獲勝");
            }

        }

        public int Buff()
        {
            while (true)
            {
                Console.WriteLine("請選擇能力Buff:");
                Console.WriteLine("1.攻擊+2");
                Console.WriteLine("2.敏捷+2");
                Console.WriteLine("3.防禦+2");
                Console.WriteLine("4.死亡時補HP5藥水(需扣除死亡時血量負值)");
                Console.WriteLine("5.隨機跳關");

                int select = int.Parse(Console.ReadLine());
                int round = 0;
                switch (select)
                {
                    case 1:
                        if (this.item1)
                        {
                            this.Att += 2;
                            this.item1 = false;
                            return 0;
                        }
                        else
                        {
                            Console.WriteLine("該選項已使用，請重新選擇");
                        }
                        break;
                    case 2:
                        if (this.item2)
                        {
                            this.Agi += 2;
                            this.item2 = false;
                            return 0;
                        }
                        else
                        {
                            Console.WriteLine("該選項已使用，請重新選擇");
                        }
                        break;
                    case 3:
                        if (this.item3)
                        {
                            this.Def += 2;
                            this.item3 = false;
                            return 0;
                        }
                        else
                        {
                            Console.WriteLine("該選項已使用，請重新選擇");
                        }
                        break;
                    case 4:
                        if (this.item4)
                        {
                            Console.WriteLine("該項目已選擇使用，請重新選擇");
                        }
                        else
                        {
                            this.item4 = true;
                        }
                        break;
                    case 5:
                        Console.WriteLine("隨機跳關");
                        Random random = new Random();
                        round = random.Next(5, 11);
                        return round;

                }
            }


        }

        public bool Avoid(Game player,Game Boss)
        {
            int agi = player.Agi - Boss.Agi;
            Random random = new Random();
            int temp = random.Next(1, 10);
            if (temp - agi > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }


}

