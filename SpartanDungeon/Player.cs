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

        public Inventory inventory { get; private set; } = new Inventory(); 

        public Player()
        {
            curHp = maxHp;
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
