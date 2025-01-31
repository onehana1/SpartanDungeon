using static SpartanDungeon.MainScene;

namespace SpartanDungeon
{

    internal class MainScene
    {





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
            var menu = new MainMenu(player);


            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            player.SetPlayerName();  // 이름 세팅  
            Console.WriteLine($"{player.name}님 이시군요! 반갑습니다.\n");

            player.SetPlayerJob();   // 직업 세팅

            Console.WriteLine($"스파르타 마을에 오신 {player.name}님을 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            menu.ShowMenu();

        }
    }
}


