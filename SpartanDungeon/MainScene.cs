using static SpartanDungeon.MainScene;

namespace SpartanDungeon
{

    internal class MainScene
    {

        enum Job
        {
            Warrior,
            Archer,
            Magician
        }

        enum MenuOption
        {
            Status = 1,
            Inventory,
            Shop,
            Exit
        }

        private static readonly Dictionary<MenuOption, string> MenuDescriptions = new Dictionary<MenuOption, string>
        {
            { MenuOption.Status, "상태 보기" },
            { MenuOption.Inventory, "인벤토리" },
            { MenuOption.Shop, "상점" },
            { MenuOption.Exit, "게임 종료" }
        };

        public class Player
        {
            public string name { get; set; }
            public int level { get; set; } = 1;
            
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
                        Console.WriteLine($"{(int)option}. {MenuDescriptions[option]}");
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
                }
            }

            private void ShowStatus()
            {
                Console.WriteLine($"\n[상태 보기]\n이름: {player.name}\n레벨: {player.level}\n");
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
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.\n");

            var player = new Player();

            player.name = Console.ReadLine();

            Console.WriteLine($"{player.name}님 이시군요! 반갑습니다.\n");


            Console.WriteLine($"스파르타 마을에 오신 {player.name}님을 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            var menu = new MainMenu(player);
            menu.ShowMenu();




        }
    }
}
