﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace SpartanDungeon
{
    public class MainMenu
    {
        private Player player;
        private Store store;
        private Rest rest;
        private Dungeon dungeon;
        public MainMenu(Player player, Store store, Rest rest, Dungeon dungeon)
        {
            this.player = player;
            this.store = store;
            this.rest = rest;   
            this.dungeon = dungeon;
        }


        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
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
                           Console.Clear();
                            ShowStatus();
                            break;
                        case MenuOption.Inventory:
                            Console.Clear();
                            ShowInventoryMenu();
                            break;
                        case MenuOption.Shop:
                            Console.Clear();
                            ShowStore();
                            break;
                        case MenuOption.Rest:
                            Console.Clear();
                            ShowRest();
                            break;
                        case MenuOption.Dungeon:
                            Console.Clear();
                            ShowDungeon();
                            break;
                        case MenuOption.SaveGame:
                            Console.Clear();
                            SaveLoadManager.SavePlayerData(player);
                            Console.WriteLine("지금까지의 데이터를 저장합니다.");
                            Console.WriteLine("계속해서 게임을 진행하고 싶다면 아무키나 입력해주세요.");

                            Console.ReadKey();
                            break;
                        case MenuOption.LeaveGame:
                            Console.Clear();
                            SaveLoadManager.SavePlayerData(player);
                            Console.WriteLine("지금까지의 데이터를 저장합니다.\n게임을 종료합니다.\n안녕!");
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
                $"공격력: {player.baseOffensive + player.plusOffensive} (+{player.plusOffensive}), " +
                $"방어력: {player.baseDefensive + player.plusDefensive} (+{player.plusDefensive})" +
                $"\n체력: {player.curHp} / {player.maxHp}\n" +
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

        private void ShowStore()
        {
            store.ShowStoreMenu();
            // CloseMenu();
        }

        private void ShowRest()
        {
           rest.ShowRestMenu();
        }

        private void ShowDungeon()
        {
            dungeon.ShowDungeonMenu();
        }
    }
}
