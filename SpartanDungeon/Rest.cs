using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpartanDungeon
{
    public class Rest
    {
        private Player player;

        public Rest(Player player)
        {
            this.player = player;
        }

        public void ShowRestMenu()
        {
            while (true)
            {
                Console.WriteLine("\n[휴식하기]");
                Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다." +
                    $"\n(보유 골드 : {player.gold} G / 현재 체력: {player.curHp})\n");

                Console.WriteLine("1. 휴식하기");
                Console.WriteLine("0. 나가기");
                Console.Write("\n원하는 행동을 선택하세요: ");

                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    RestMenuOption choice = (RestMenuOption)input;
                    switch (choice)
                    {
                        case RestMenuOption.PlayerRest:
                            PlayerRest();
                            break;

                        case RestMenuOption.ExitMenu:
                            return;
                        default:
                            Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        public void PlayerRest()
        {
            if (player.gold < (int)RestMenuOption.RestGold)
            {
                Console.WriteLine($"보유 골드 : {player.gold} G");
                Console.WriteLine($"골드가 부족합니다.");
                return;
            }
            else if (player.curHp == player.maxHp)
            {
                Console.WriteLine($"더이상 회복할 수 없습니다. 이미 최대 체력입니다.");
                return;
            }

            player.gold -= (int)RestMenuOption.RestGold;
            player.curHp = Math.Min(player.curHp + (int)RestMenuOption.MaxHeal, player.maxHp);
            Console.WriteLine($"휴식을 완료했습니다. 현재 체력: {player.curHp}");

            Console.WriteLine($"보유 골드 : {player.gold} G");

        }
    }
}
