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
                            ShowInventoryMenu();
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

        private void ShowInventoryMenu()
        {
            while (true)
            {
                Console.WriteLine("\n인벤토리\n보유 중인 아이템을 관리할 수 있습니다.");
                player.inventory.ShowInventory(); // 현재 인벤토리 출력

                Console.WriteLine("\n1. 장착 관리");
                Console.WriteLine("0. 나가기");
                Console.Write("\n원하시는 행동을 입력해주세요: ");

                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    InventoryMenuOption choice = (InventoryMenuOption)input; 

                    if (choice == InventoryMenuOption.ExitMenu) return; 
                    if (choice == InventoryMenuOption.ManageEquipment) ManageEquipment();
                    else Console.WriteLine("잘못된 입력입니다.");
                }

            }
        }

        private void ManageEquipment()
        {
            while (true)
            {
                Console.WriteLine("\n[장착 관리]\n보유 중인 아이템을 관리할 수 있습니다.");
                player.inventory.ShowInventoryWithNumbers(); // 번호가 포함된 인벤토리 출력

                Console.WriteLine("\n0. 나가기");
                Console.Write("\n장착/해제할 아이템 번호를 입력해주세요: ");

                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input == 0) return; // 0을 입력하면 장착 관리 종료

                    bool success = player.inventory.ToggleEquipItem(input); // 장착/해제
                    if (!success) Console.WriteLine("잘못된 입력입니다."); 
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }


        private void ShowShop()
        {
            Console.WriteLine("\n[상점]\n아직 상점이 준비되지 않았습니다.\n");

            CloseMenu();
        }
    }
}
