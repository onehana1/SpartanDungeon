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
        public int offensive { get; set; } = 0;
        public int defensive { get; set; } = 0;

        public int maxHp { get; set; } = 100;
        public int curHp { get; set; }

        public int gold { get; set; } = 0;


        // 인벤토리
        public List<Item> inventory { get; private set; } = new List<Item>();


        public Player()
        {
            curHp = maxHp;
        }

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
                    Console.WriteLine($"{GameData.JobDescriptions[choice]}을(를) 선택하셨습니다.");
                    this.job = choice;
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                }
            }
        }

    }
}
