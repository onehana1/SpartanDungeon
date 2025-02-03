using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpartanDungeon
{

    public class Player
    {
        public string name { get; set; }
        public Job job { get; set; }
        public int level { get; set; } = 1;

        public int baseOffensive { get; private set; } = 10; 
        public int baseDefensive { get; private set; } = 10;  

        public int plusOffensive { get; set; } = 0;
        public int plusDefensive { get; set; } = 0;

        public int maxHp { get; set; } = 100;
        public int curHp { get; set; }

        public int gold { get; set; } = 10000;

        public Inventory inventory { get; private set; }


        public Player()
        {
            curHp = maxHp;
            inventory = new Inventory(this);
        }

       

        public void SetPlayerName()
        {
            Console.WriteLine("원하시는 이름을 설정해주세요.\n");
            this.name = Console.ReadLine();
        }

        public void SetPlayerJob()
        {
            while (true)
            {
                Console.WriteLine("원하시는 직업을 골라주세요.\n");

                foreach (Job option in Enum.GetValues(typeof(Job)))
                {
                    Console.WriteLine($"{(int)option}. {GameData.JobDescriptions[option]}");
                }
                Console.Write("\n선택: ");

                if (int.TryParse(Console.ReadLine(), out int input) && Enum.IsDefined(typeof(Job), input))
                {
                    Job choice = (Job)input;
                    
                    this.job = choice;
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                }
            }
        }

        public void ToggleEquipItem(Item item)
        {
            if (!item.isEquipment) return; // 장비가 아니면 무시

            int equipmentId = item.id;
            int equipmentPart = item.part;

            // 같은 아이템을 다시 선택하면 해제
            if (inventory.equippedItems.ContainsKey(equipmentPart) && inventory.equippedItems[equipmentPart] == item)
            {
                Console.WriteLine($"{inventory.equippedItems[equipmentPart].name}을(를) 장착 해제했습니다.");
                inventory.equippedItems.Remove(equipmentPart);
            }
            else
            {
                // 기존 장비 해제 후 새로운 장비 장착
                if (inventory.equippedItems.ContainsKey(equipmentPart))
                {
                    Console.WriteLine($"{inventory.equippedItems[equipmentPart].name}을(를) 해제하고 {item.name}을(를) 장착했습니다.");
                    inventory.equippedItems.Remove(equipmentPart);
                }
                else
                {
                    Console.WriteLine($"{item.name}을(를) 장착했습니다");
                }

                inventory.equippedItems[equipmentPart] = item; // 장비 장착
            }

            UpdateStats(); // 스탯 업데이트
        }

        private void UpdateStats()
        {
            plusOffensive = 0;
            plusDefensive = 0;
            foreach (var item in inventory.equippedItems.Values)
            {
                plusOffensive += item.offensive;
                plusDefensive += item.defensive;
            }

            Console.WriteLine($"[스탯 업데이트] 공격력: {baseOffensive + plusOffensive} (+{plusOffensive}), " +
                $"방어력: {baseDefensive + plusDefensive} (+{plusDefensive})");
        }


    }
}
