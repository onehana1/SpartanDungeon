using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace SpartanDungeon
{
    public class Dungeon
    {
        private Player player;
        public List<DungeonInfo> dungeons { get; private set; } = new List<DungeonInfo>();

        public Dungeon(Player player)
        {
            this.player = player;
            dungeons = new List<DungeonInfo>(GameData.dungeons);
        }

        public void ShowDungeonMenu()
        {
            while (true)
            {
                Console.WriteLine("\n[던전입장]");
                Console.WriteLine($"이곳에서 던전으로 들어가기전 활동을 할 수 있습니다." +
                    $"\n(현재 방어력 : {player.curDefensive}  / 현재 체력: {player.curHp})\n");

                //Console.WriteLine($"1. 쉬운 던전   | 방어력 {5} 이상 권장");
                //Console.WriteLine($"2. 일반 던전   | 방어력 {11} 이상 권장");
                //Console.WriteLine($"3. 어려운 던전 | 방어력 {17} 이상 권장");

                int index = 1;
                String str = " 이상 권장";
                foreach (var dun in dungeons)
                {
                    Console.WriteLine($"{Utill.LetterSpacing(index.ToString(), 2)}" +
                        $" {Utill.LetterSpacing(dun._name, 15)}" +
                        $"| 방어력 {Utill.LetterSpacing(dun.rDef.ToString()+ str, 5)}");
                    index++;
                }

                Console.WriteLine("0. 나가기");
                Console.Write("\n원하는 행동을 선택하세요: ");

                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input == 0) return;

                    if (player.curHp <= 0)
                    {
                        Console.WriteLine($"\n체력이 부족하여 던전에 입장할 수 없습니다.\n");
                        Console.WriteLine("휴식을 통해 체력을 회복하세요.");
                        continue; 
                    }

                    DungeonInfo selectedDungeon = GameData.GetDungeonById(input);
                    if (selectedDungeon != null)
                    {
                        GoDungeon(selectedDungeon);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 숫자를 입력해주세요.");
                }
            }
        }

        private static Random random = new Random();

        private void GoDungeon(DungeonInfo dungeon)
        {
            Console.WriteLine($"\n[{dungeon._name}]에 입장합니다.\n");
            if (player.curDefensive < dungeon.rDef)
            {
                if (random.Next(0, 100) < 40)
                {
                    FailDungeon(dungeon);
                    return;
                }
            }
            ClearDungeon(dungeon);
        }

        private void FailDungeon(DungeonInfo dungeon)
        {
            Console.WriteLine("[던전 실패]");
            Console.WriteLine($"{dungeon._name} 클리어에 실패하셨습니다...\n");

            Console.Write($"체력: {player.curHp} -> ");
            player.curHp -= dungeon.reduceHp;
            player.curHp = Math.Max(0, player.curHp);
            Console.WriteLine($"{player.curHp}");

        }

        private void ClearDungeon(DungeonInfo dungeon)
        {
            Console.WriteLine("[던전 클리어]");
            Console.WriteLine($"{dungeon._name} 클리어에 성공하셨습니다!\n");

            // 체력
            int defGap = (int)player.curDefensive - dungeon.rDef;    // 내 방어력 던전 방어력 갭
            int reduceHpAmount = random.Next(dungeon.reduceHp + defGap, dungeon.reduceHp + 16 + defGap); // 체력 감소량

            Console.Write($"체력: {player.curHp} -> ");

            player.curHp -= reduceHpAmount;
            player.curHp = Math.Max(0, player.curHp);

            Console.WriteLine($"{player.curHp}");

            // 보상
            int rewardGold = dungeon.RewardGold;
            int plusGoldPercent;
            plusGoldPercent = random.Next((int)player.curOffensive, (int)player.curOffensive * 2);
            rewardGold += rewardGold * (plusGoldPercent/100);

            Console.Write($"보유 골드: {player.gold} G -> ");
            player.gold += rewardGold;
            Console.WriteLine($"{player.gold} G");

            player.clearDungeonCount++;  // 클리어 횟수 증가
            if (player.clearDungeonCount >= player.level)
            {
                player.LevelUp();
            }

        }
    }
}
