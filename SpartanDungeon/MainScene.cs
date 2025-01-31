using static SpartanDungeon.MainScene;

namespace SpartanDungeon
{

    internal class MainScene
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

            public Player()
            {
                curHp = maxHp;
            }

        }

        public class SettingPlayer
        {
            private Player player;
            public SettingPlayer(Player player)
            {
                this.player = player;
            }

            public void SetPlayerName()
            {
                Console.WriteLine("원하시는 이름을 설정해주세요.\n");
                player.name = Console.ReadLine();
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
                        player.job = choice;
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                    }
                }
        }


            public class MainMenu
            {
                private Player player;

                public MainMenu(Player player)
                {
                    this.player = player;
                }

                public void ShowMenu()
                {
                    while (true)
                    {
                        foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
                        {
                            Console.WriteLine($"{(int)option}. {GameData.MenuDescriptions[option]}");
                        }

                        Console.Write("\n원하시는 행동을 입력해주세요: ");
                        if (int.TryParse(Console.ReadLine(), out int input) && Enum.IsDefined(typeof(MenuOption), input))
                        {
                            MenuOption choice = (MenuOption)input;


                            switch (choice)
                            {
                                case MenuOption.Status:
                                    ShowStatus();
                                    break;
                                case MenuOption.Inventory:
                                    ShowInventory();
                                    break;
                                case MenuOption.Shop:
                                    ShowShop();
                                    break;
                                case MenuOption.Exit:
                                    Console.WriteLine("게임을 종료합니다.");
                                    return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                    }
                }

                private void ShowStatus()
                {
                    Console.WriteLine($"\n[상태 보기]\n이름: {player.name}  ({GameData.JobDescriptions[player.job]})\n레벨: {player.level}\n" +
                        $"공격력: {player.offensive}\n방어력: {player.defensive}\n체력: {player.curHp} / {player.maxHp}\n" +
                        $"골드: {player.gold} G");
                }

                private void ShowInventory()
                {
                    Console.WriteLine("\n[인벤토리]\n현재 아이템이 없습니다.\n");
                }

                private void ShowShop()
                {
                    Console.WriteLine("\n[상점]\n아직 상점이 준비되지 않았습니다.\n");
                }
            }

            static void Main(string[] args)
            {
                var player = new Player();
                var setP = new SettingPlayer(player);
                var menu = new MainMenu(player);


                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                setP.SetPlayerName();  // 이름 세팅  
                Console.WriteLine($"{player.name}님 이시군요! 반갑습니다.\n");

                setP.SetPlayerJob();   // 직업 세팅

                Console.WriteLine($"스파르타 마을에 오신 {player.name}님을 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

                menu.ShowMenu();

            }
        }
    }
}

