using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanDungeon
{
    public class Inventory
    {
        public List<Item> inventory { get; private set; } = new List<Item>();
        
        public Dictionary<int, Item> equippedItems = new Dictionary<int, Item>();    // 장착된 아이템 저장

        private Player player;
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
                                            equippedItems.ContainsValue(item) ? "[E]" : ""; // 장착된 아이템 표시
                    Console.WriteLine($"- {item.name} {equippedMark} ({(item.isEquipment ? "장비" : "소모품")})"); //장비 또는 소모품 표시

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
                    string equippedMark = equippedItems.ContainsValue(item) ? "[E] " : ""; 
                    string stats = $"{(item.offensive > 0 ? $"공격력 +{item.offensive} " : "")}" +
                        $"{(item.defensive > 0 ? $"방어력 +{item.defensive}" : "")}";

                    Console.WriteLine(
                           $"{LetterSpacing(index.ToString(), 5)} " +
                           $"{LetterSpacing(equippedMark + item.name, 20)} | " +
                           $"{LetterSpacing(stats, 25)} | " +
                           $"{item.description}"
                       );
                    index++;
                }

            }
        }

        public static string LetterSpacing(string text, int width)
        {
            int textWidth = 0;

            foreach (char c in text)
            {
                if (char.IsWhiteSpace(c))   //공백 체크
                    textWidth += 1; 
                else if (c > 255)
                    textWidth += 2;  // 255 이상은 한글 -> 2칸
                else
                    textWidth += 1;  // 나머지 1칸
            }

            return text + new string(' ', width - textWidth);
        }


        // 아이템 장착/해제 기능
        public bool ToggleEquipItem(int invenIndex)
        {
            if (invenIndex < 1 || invenIndex > inventory.Count) return false; // 인벤 인덱스는 1부터 시작함

            Item itemToEquip = inventory[invenIndex - 1]; // 근데 인벤은 0부터 있음
            if (!itemToEquip.isEquipment) return false; // 장비가 아니면x

            player.ToggleEquipItem(itemToEquip);    // 플레이어에 장착
            return true;
        }



        public void UseItem(int itemId)
        {

        }


    }
}
