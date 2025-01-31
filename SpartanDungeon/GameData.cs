using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanDungeon
{
    public enum Job
    {
        Warrior = 1,
        Archer,
        Magician
    }
    public enum MenuOption
    {
        Status = 1,
        Inventory,
        Shop,
        Exit
    }

    public static class GameData
    {

        public static readonly Dictionary<Job, string> JobDescriptions = new Dictionary<Job, string>
        {
            { Job.Warrior, "전사" },
            { Job.Archer, "궁수" },
            { Job.Magician, "마법사" }
        };


        public static readonly Dictionary<MenuOption, string> MenuDescriptions = new Dictionary<MenuOption, string>
        {
            { MenuOption.Status, "상태 보기" },
            { MenuOption.Inventory, "인벤토리" },
            { MenuOption.Shop, "상점" },
            { MenuOption.Exit, "게임 종료" }
        };

    }
}
