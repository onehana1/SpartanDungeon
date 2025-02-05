using static SpartanDungeon.MainScene;

namespace SpartanDungeon
{

    internal class MainScene
    {

        static void Main(string[] args)
        {

            Player player;
            Store store;
            Rest rest;
            Dungeon dungeon;
            MainMenu menu;

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");

            while (true)
            {
                Console.WriteLine("\n1. 새 게임 시작");
                Console.WriteLine("2. 저장된 파일 불러오기");
                Console.Write("\n선택: ");

                if (int.TryParse(Console.ReadLine(), out int input) && Enum.IsDefined(typeof(StartMenuOption), input))
                {
                    StartMenuOption choice = (StartMenuOption)input;

                    if (choice == StartMenuOption.NewGame)
                    {
                        player = new Player();
                        Console.WriteLine("\n새로운 게임을 시작합니다!\n");
                        player.SetPlayerName();
                        Console.WriteLine($"{player.name}님 이시군요! 반갑습니다.\n");
                        player.SetPlayerJob();
                        break;
                    }
                    else if (choice == StartMenuOption.LoadPlayer)
                    {
                        player = SaveLoadManager.LoadPlayerData();
                        if (player != null)
                        {
                            Console.WriteLine("\n저장된 데이터를 불러왔습니다!\n");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                    }
                }
                   
            }
            store = new Store(player);
            rest = new Rest(player);
            dungeon = new Dungeon(player);
            menu = new MainMenu(player, store, rest, dungeon);


            Console.WriteLine($"\n{GameData.JobDescriptions[player.job]}을(를) 선택하셨습니다.");
            Console.WriteLine($"스파르타 마을에 오신 {player.name}님을 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");


            if (player.inventory.inventory.Count == 0){         // 인벤 비어있으면 추가
                player.inventory.AddItem((int)Equipment.OldArmor);
                player.inventory.AddItem((int)Equipment.SpartaArmor);
                player.inventory.AddItem((int)Equipment.OldSword);
                player.inventory.AddItem((int)Equipment.OldGloves);
                player.inventory.AddItem((int)ConsumableItem.EasyHpPotion);
                player.inventory.AddItem((int)ConsumableItem.EasyManaPotion);
            }

            menu.ShowMenu();


        }
    }
}


