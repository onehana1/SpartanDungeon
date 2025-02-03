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
        
        private Dictionary<Equipments, Item> equippedItems = new Dictionary<Equipments, Item>();    // 장착된 아이템 저장



        public void AddItem(Item item)
        {
            inventory.Add(item);
            Console.WriteLine($"{item.name}을(를) 획득했습니다!");
        }
        public void ShowInventory()
        {
            Console.WriteLine("\n[인벤토리]");
            if (inventory.Count == 0)
            {
                Console.WriteLine("현재 아이템이 없습니다.");
            }
            else
            {
                foreach (var item in inventory)
                {
                    string equippedMark = equippedItems.ContainsValue(item) ? "[E]" : ""; // 장착된 아이템 표시
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
                    string equippedMark = equippedItems.ContainsValue(item) ? "[E]" : ""; // 장착된 아이템 표시
                    string itemInfo = item.isEquipment
                         ? $"| {(item.offensive > 0 ? $"공격력 +{item.offensive}" : $"방어력 +{item.defensive}")} | {item.description}"
                         : $"| {item.description}";     // 장비 아니면 설명만

                    Console.WriteLine($"- {index} {equippedMark}{item.name} {itemInfo}");
                    index++;
                }
            }
        }

        // 아이템 장착/해제 기능
        public bool ToggleEquipItem(int itemIndex)
        {
            if (itemIndex < 1 || itemIndex > inventory.Count) return false; // 인벤 인덱스는 1부터 시작함

            Item itemToEquip = inventory[itemIndex - 1]; // 근데 인벤은 0부터 있음
            if (!itemToEquip.isEquipment) return false; // 장비가 아니면x

            Equipments equipmentType = (Equipments)itemToEquip.id; // 아이템 id (부위) -> Equipments (부위)

            if (equippedItems.ContainsKey(equipmentType))
            {
                // 이미 장착 중이면 해제
                Console.WriteLine($"{equippedItems[equipmentType].name}을(를) 장착 해제했습니다.");
                equippedItems.Remove(equipmentType);
            }
            else
            {
                // 장착 실행
                equippedItems[equipmentType] = itemToEquip;
                Console.WriteLine($"{itemToEquip.name}을(를) 장착했습니다!");
            }

            return true;
        }


        public void UseItem(int itemId)
        {

        }


    }
}
