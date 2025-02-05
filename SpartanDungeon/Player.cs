using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpartanDungeon
{
    public class Player
    {
        public string name { get; set; }
        public Job job { get; set; }
        public int level { get; set; } = 1;
        public int clearDungeonCount { get; set; } = 0;

        public float baseOffensive { get; set; } = 10; 
        public float baseDefensive { get; set; } = 10;

        public float plusOffensive { get; set; }
        public float plusDefensive { get; set; }
        public float curOffensive { get; set; } = 0;
        public float curDefensive { get; set; } = 0;


        public int maxHp { get; set; } = 100;
        public int curHp { get; set; }

        public int gold { get; set; } = 10000;

        public Inventory inventory { get; set; }


        public Player()
        {
            curHp = maxHp;
            inventory = new Inventory(this);
        }


        [JsonConstructor]
        public Player(string name, Job job, int level, int clearDungeonCount, float baseOffensive, float baseDefensive, float plusOffensive, float plusDefensive, float curOffensive, float curDefensive, int maxHp, int curHp, int gold, Inventory inventory) // JSON에서 불러올 때 실행되는 생성자...
        {    
            this.name = name;
            this.job = job;
            this.level = level;
            this.clearDungeonCount = clearDungeonCount;
            this.baseOffensive = baseOffensive;
            this.baseDefensive = baseDefensive;
            this.plusOffensive = plusOffensive;
            this.plusDefensive = plusDefensive;
            this.curOffensive = curOffensive;
            this.curDefensive = curDefensive;
            this.maxHp = maxHp;
            this.curHp = curHp;
            this.gold = gold;
            this.inventory = inventory ?? new Inventory(this);  // null이면 새 인벤토리 생성

            if (inventory != null)
            {
                inventory.SetPlayer(this);  // 역직렬화 후 player 연결
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
                    
                    this.job = choice;
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                }
            }
        }


        public void UpdateStats()
        {
            plusOffensive = 0;
            plusDefensive = 0;
            foreach (var itemId in inventory.equippedItems.Values)
            {
                Item item = GameData.GetItemById(itemId);
                plusOffensive += item.offensive;
                plusDefensive += item.defensive;
            }

            curDefensive = baseDefensive + plusDefensive;
            curOffensive = baseOffensive + plusOffensive;

            Console.WriteLine($"[스탯 업데이트] 공격력: {curOffensive} (+{plusOffensive}), " +
                $"방어력: {curDefensive} (+{plusDefensive})");
        }

        public void LevelUp()
        {
            clearDungeonCount = 0; // 클리어 횟수 초기화
            level++;  // 레벨 증가
            baseOffensive += 0.5f;
            baseDefensive += 1;

            Console.WriteLine($"\n레벨 업! Lv{level} 가 되었습니다!");
            Console.WriteLine($"기본 공격력: {baseOffensive} (+0.5), 방어력: {baseDefensive} (+1)");

            UpdateStats();
        }


    }
}
