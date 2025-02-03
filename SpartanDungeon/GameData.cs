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
        ExitMenu = 0,
        Status = 1,
        Inventory,
        Shop,
        LeaveGame
    }

    public enum Equipments
    {
        Top = 1,
        Bottoms,
        Shoes,
        Gloves,
        Weapon,

        LAST
    }

    public enum Items
    {
        ManaPotion = Equipments.LAST,
        HpPotion
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
            { MenuOption.LeaveGame, "게임 종료" }
        };


        public static readonly Dictionary<Equipments, Item> EquipmentItems = new Dictionary<Equipments, Item>
        {
            { Equipments.Top, new Item((int)Equipments.Top, "갑옷", true) },
            { Equipments.Bottoms, new Item((int)Equipments.Bottoms, "바지", true) },
            { Equipments.Shoes, new Item((int)Equipments.Shoes, "신발", true) },
            { Equipments.Gloves, new Item((int)Equipments.Gloves, "장갑", true) },
            { Equipments.Weapon, new Item((int)Equipments.Weapon, "검", true) }
        };

        public static readonly Dictionary<Items, Item> ConsumableItems = new Dictionary<Items, Item>
        {
            { Items.ManaPotion, new Item((int)Items.ManaPotion, "마나 포션", false) },
            { Items.HpPotion, new Item((int)Items.HpPotion, "체력 포션", false) }
        };


    }
}
