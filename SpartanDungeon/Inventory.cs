using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpartanDungeon
{
    public class Inventory
    {
        public List<Item> inventory { get; set; } = new List<Item>();

        public Dictionary<string, int> equippedItems { get; set; } = new Dictionary<string, int>();


        private Player player;

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public Inventory() { }  
        public Inventory(Player player)
        {
            this.player = player;
        }


        public void AddItem(int itemId)
        {
            Item item = GameData.GetItemById(itemId);   // 아이디로 아이템 찾아야됨
            if (item == null)
            {
                Console.WriteLine("아이템 이상한데요");
                return;
            }
            inventory.Add(item);
            Console.WriteLine($"{item.name}을(를) 획득했습니다!");
        }
        public void ShowInventory()
        {
            Console.WriteLine("\n[인벤토리]");
            if (inventory == null || inventory.Count == 0)
            {
                Console.WriteLine("현재 아이템이 없습니다.");
            }
            else
            {
                foreach (var item in inventory)
                {
                    string equippedMark = equippedItems != null && item != null && 
                                            equippedItems.Values.Contains(item.id) ? "[E]" : ""; // 장착된 아이템 표시
                    Console.WriteLine($"- {equippedMark} {item.name} ({(item.isEquipment ? "장비" : "소모품")})"); //장비 또는 소모품 표시

                }
            }
        }

        public void ShowInventoryWithNumbers()
        {
            Console.WriteLine("\n[인벤토리]");
            if (inventory.Count == 0)
            {
                Console.WriteLine("현재 아이템이 없습니다.");
            }
            else
            {

                int index = 1;

                foreach (var item in inventory)
                {
                    string equippedMark = equippedItems.Values.Contains(item.id) ? "[E] " : ""; 
                    string stats = $"{(item.offensive > 0 ? $"공격력 +{item.offensive} " : "")}" +
                        $"{(item.defensive > 0 ? $"방어력 +{item.defensive}" : "")}";

                    Console.WriteLine(
                           $"{Utill.LetterSpacing(index.ToString(), 5)} " +
                           $"{Utill.LetterSpacing(equippedMark + item.name, 20)} | " +
                           $" {Utill.LetterSpacing(stats, 20)} | " +
                           $" {Utill.LetterSpacing(item.description, 40)} |" +
                           $" {item.price} G"
                       );
                    index++;
                }

            }
        }




        // 아이템 장착/해제 기능
        public bool ToggleEquipItem(int invenIndex)
        {
            if (invenIndex < 1 || invenIndex > inventory.Count) return false; // 인덱스 체크

            Item itemToEquip = inventory[invenIndex - 1]; // 인덱스 변환
            if (!itemToEquip.isEquipment) return false; // 장비가 아니면 x

            string equipmentPart = itemToEquip.part.ToString(); // 부위 문자열 변환

            // 현재 장착 중인 아이템이 같은 부위에 있는지 확인
            if (equippedItems.ContainsKey(equipmentPart))
            {
                int equippedItemId = equippedItems[equipmentPart]; // 현재 장착된 아이템 ID
                if (equippedItemId == itemToEquip.id)
                {
                    // 같은 아이템을 다시 선택하면 해제
                    Console.WriteLine($"{itemToEquip.name}을(를) 장착 해제했습니다.");
                    equippedItems.Remove(equipmentPart);
                }
                else
                {
                    // 다른 아이템을 선택하면 기존 장비 해제 후 새 아이템 장착
                    Console.WriteLine($"{GameData.GetItemById(equippedItemId).name}을(를) 해제하고 {itemToEquip.name}을(를) 장착했습니다.");
                    equippedItems[equipmentPart] = itemToEquip.id;
                }
            }
            else
            {
                // 새 아이템을 장착
                Console.WriteLine($"{itemToEquip.name}을(를) 장착했습니다.");
                equippedItems[equipmentPart] = itemToEquip.id;
            }

            player.UpdateStats(); // 스탯 업데이트

            return true;
        }




        public void UseItem(int itemId)
        {

        }


    }
}
