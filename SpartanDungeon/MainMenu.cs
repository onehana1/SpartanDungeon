using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanDungeon
{
    public class MainMenu
    {
        private Player player;

        public MainMenu(Player player)
        {
            this.player = player;
        }

        public void ShowMenu()
        {
            while (true)
            {
                foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
                {
                    if (option == MenuOption.ExitMenu) continue;    // exitmenu 는 보여줄 필요없고 dic에도 안넣을거임
                    Console.WriteLine($"{(int)option}. {GameData.MenuDescriptions[option]}");
                }

                Console.Write("\n원하시는 행동을 입력해주세요: ");
                if (int.TryParse(Console.ReadLine(), out int input) && Enum.IsDefined(typeof(MenuOption), input))
                {
                    MenuOption choice = (MenuOption)input;


                    switch (choice)
                    {
                        case MenuOption.Status:
                            ShowStatus();
                            break;
                        case MenuOption.Inventory:
                            ShowInventory();
                            break;
                        case MenuOption.Shop:
                            ShowShop();
                            break;
                        case MenuOption.LeaveGame:
                            Console.WriteLine("게임을 종료합니다.");
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        private void CloseMenu()
        {
            Console.Write("\n0. 나가기 \n\n원하시는 행동을 입력해주세요:");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input) && input == (int)MenuOption.ExitMenu)
                {
                    break;
                }
                Console.Write("\n잘못된 입력입니다. 0을 입력하여 나가세요: ");
            }

        }


        private void ShowStatus()
        {
            Console.WriteLine($"\n[상태 보기]\n이름: {player.name}  ({GameData.JobDescriptions[player.job]})\n레벨: {player.level}\n" +
                $"공격력: {player.offensive}\n방어력: {player.defensive}\n체력: {player.curHp} / {player.maxHp}\n" +
                $"골드: {player.gold} G");

            CloseMenu();
        }

        private void ShowInventory()
        {
            player.inventory.ShowInventory();

            CloseMenu();
        }

        private void ShowShop()
        {
            Console.WriteLine("\n[상점]\n아직 상점이 준비되지 않았습니다.\n");

            CloseMenu();
        }
    }
}
