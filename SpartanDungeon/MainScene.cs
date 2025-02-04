﻿using static SpartanDungeon.MainScene;

namespace SpartanDungeon
{

    internal class MainScene
    {
       

        static void Main(string[] args)
        {
            var player = new Player();
            var store = new Store(player);
            var rest = new Rest(player);
            var dungeon = new Dungeon(player);
            var menu = new MainMenu(player, store, rest, dungeon);

 


            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            player.SetPlayerName();  // 이름 세팅  
            Console.WriteLine($"{player.name}님 이시군요! 반갑습니다.\n");

            player.SetPlayerJob();   // 직업 세팅
            //Console.Clear();
            Console.WriteLine($"\n{GameData.JobDescriptions[player.job]}을(를) 선택하셨습니다.");
            Console.WriteLine($"스파르타 마을에 오신 {player.name}님을 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");


            player.inventory.AddItem((int)Equipment.OldArmor);
            player.inventory.AddItem((int)Equipment.SpartaArmor);
            player.inventory.AddItem((int)Equipment.OldSword);
            player.inventory.AddItem((int)Equipment.OldGloves);


            player.inventory.AddItem((int)ConsumableItem.EasyHpPotion);
            player.inventory.AddItem((int)ConsumableItem.EasyManaPotion); 

            menu.ShowMenu();


        }
    }
}


