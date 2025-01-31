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
                    Console.WriteLine($"- {item.name} ({(item.isEquipment ? "장비" : "소모품")})");
                }
            }
        }

        public void UseItem(int itemId)
        {

        }


    }
}
