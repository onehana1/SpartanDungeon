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

    public enum InventoryMenuOption
    {
        ExitMenu = 0,
        ManageEquipment

    }

    public enum EquipmentType  //부위
    {
        Armor = 1,
        Shoes,
        Gloves,
        Weapon,

        LAST
    }

    public enum ConsumableItemType //부위
    {
        ManaPotion = EquipmentType.LAST,
        HpPotion
    }

    public enum Equipment
    {
        OldArmor,
        SpartaArmor,
        OldSword,
        SpartaSword,
        OldGloves,
        SpartaGloves,
        OldShoes,
        SpartaShoes,

        Last

    }
    public enum ConsumableItem
    {
        EasyHpPotion = Equipment.Last,
        GreatHpPotion,
        EasyManaPotion,
        GreatManaPotion,
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


        public static readonly List<Item> Items = new List<Item>
        { 
            // 장비 아이템
            new Item((int)Equipment.OldArmor,(int)EquipmentType.Armor, "낡은 갑옷", true, 0, 5, "어쩌구 저쩌구 갑옷입니다."),
            new Item((int)Equipment.OldShoes,(int)EquipmentType.Shoes, "낡은 신발", true, 0, 2, "어쩌구 저쩌구 신발입니다."),
            new Item((int)Equipment.OldGloves,(int)EquipmentType.Gloves, "낡은 장갑", true, 1, 1, "어쩌구 저쩌구 장갑입니다."),
            new Item((int)Equipment.OldSword,(int)EquipmentType.Weapon, "낡은 검", true, 5, 0, "어쩌구 저쩌구 검입니다."),

            // 소비 아이템
            new Item((int)ConsumableItem.EasyManaPotion,(int)ConsumableItemType.ManaPotion, "그냥 마나 포션", false, 0, 0, "사용하면 마나를 50 회복합니다."),
            new Item((int)ConsumableItem.EasyHpPotion,(int)ConsumableItemType.HpPotion, "그냥 체력 포션", false, 0, 0, "사용하면 체력을 50 회복합니다.")
        };


        public static Item GetItemById(int id)  // id 검색
        {
            return Items.Find(item => item.id == id);
        }
    }
}
