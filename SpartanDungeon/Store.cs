using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanDungeon
{
    public class Store
    {
        public List<Item> store { get; private set; } = new List<Item>();
        private Player player;

        public Store(Player player) { 
            this.player = player;
            store = new List<Item>(GameData.StoreItems);
        }


        public void ShowStoreMenu()
        {
            while (true)
            {
                Console.WriteLine("\n[상점]");
                ShowItems();
                Console.WriteLine($"\n[보유골드]\n{player.gold}\n");
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 나가기");
                Console.Write("\n원하는 행동을 선택하세요: ");

                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    StoreMenuOption choice = (StoreMenuOption)input;
                    switch (choice)
                    {
                        case StoreMenuOption.BuyMenu:
                            BuyItem();
                            break;
                        case StoreMenuOption.SellMenu:
                            SellItem();
                            break;
                        case StoreMenuOption.ExitMenu:
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

        public void ShowItems()
        {
            int index = 1;

            foreach (var item in store)
            {
                string stats = $"{(item.offensive > 0 ? $"공격력 +{item.offensive} " : "")}" +
                    $"{(item.defensive > 0 ? $"방어력 +{item.defensive}" : "")}";

                // player.inventory.ContainsValue(item) ? {item.price} : "구매완료";
                //string isHave = player.inventory.inventory.Contains(item) ? "구매 완료" : $"{item.price} G";
                string isHave = player.inventory.inventory.Any(i => i.id == item.id) ? "구매 완료" : $"{item.price} G";


                Console.WriteLine(
                       $"{Utill.LetterSpacing(index.ToString(), 5)} " +
                       $"{Utill.LetterSpacing(item.name, 20)} |" +
                       $" {Utill.LetterSpacing(stats, 20)} |" +
                       $" {Utill.LetterSpacing(item.description, 40)} |" +
                       $" {isHave}"
                   );
                index++;
            }

        }
        public void BuyItem()
        {
            ShowItems();
            Console.Write("\n\n구매할 아이템 번호를 입력하세요 (0: 나가기): ");

            if (int.TryParse(Console.ReadLine(), out int input))
            {
                if (input == 0) return;

                if (input < 1 || input > store.Count)   // 인덱스 1부터임
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
                }

                Item selectedItem = store[input - 1];

                if (player.inventory.inventory.Any(item => item.id == selectedItem.id))
                {
                    Console.WriteLine("이미 보유한 아이템입니다.");
                    return;
                }

                if (player.gold < selectedItem.price)
                {
                    Console.WriteLine("골드가 부족합니다.");
                    return;
                }

                player.gold -= selectedItem.price;
                player.inventory.AddItem(selectedItem.id);
                Console.WriteLine($"{selectedItem.name}을(를) 구매했습니다.\n\n[남은 골드]: {player.gold} G\n");
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }
        public void SellItem()
        {
            Console.WriteLine("\n[아이템 판매]");
            player.inventory.ShowInventoryWithNumbers();

            Console.Write("\n판매할 아이템 번호를 입력하세요 (0: 나가기): ");

            if (int.TryParse(Console.ReadLine(), out int input))
            {
                if (input == (int)StoreMenuOption.ExitMenu) return; // 

                if (input < 1 || input > player.inventory.inventory.Count)  // 상점 인덱스는 1부터 시작이니까
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
                }

                Item selectedItem = player.inventory.inventory[input - 1]; 

                // 장착 중인지 확인
                if (player.inventory.equippedItems.Values.Contains(selectedItem.id))
                {
                    Console.WriteLine("장착 중인 아이템은 판매할 수 없습니다.");
                    return;
                }

                int sellPrice = (int)(selectedItem.price *0.75);  // 원래 가격의 75%
                player.gold += sellPrice; 
                player.inventory.inventory.Remove(selectedItem);

                Console.WriteLine($"{selectedItem.name}을(를) {sellPrice} G에 판매했습니다. \n\n[현재 골드]: {player.gold} G\n");
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }


    }
}
