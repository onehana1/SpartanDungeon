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
        Rest,
        Dungeon,
        LeaveGame
    }

    public enum InventoryMenuOption
    {
        ExitMenu = 0,
        ManageEquipment
    }

    public enum StoreMenuOption
    {
        ExitMenu = 0,
        BuyMenu,
        SellMenu,

    }

    public enum RestMenuOption
    {
        ExitMenu = 0,
        PlayerRest,
    }


    public enum DungeonMenuOption
    {
        ExitMenu = 0,
        EasyDungeon,
        NormalDungeon,
        HardDungeon,

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
        // 직업
        public static readonly Dictionary<Job, string> JobDescriptions = new Dictionary<Job, string>
        {
            { Job.Warrior, "전사" },
            { Job.Archer, "궁수" },
            { Job.Magician, "마법사" }
        };

        // 메뉴
        public static readonly Dictionary<MenuOption, string> MenuDescriptions = new Dictionary<MenuOption, string>
        {
            { MenuOption.Status, "상태 보기" },
            { MenuOption.Inventory, "인벤토리" },
            { MenuOption.Shop, "상점" },
            { MenuOption.Rest, "휴식하기" },
            { MenuOption.Dungeon, "던전 입장" },

            { MenuOption.LeaveGame, "게임 종료" }
        };

        // 아이템
        public static readonly List<Item> Items = new List<Item>
        { 
            // 장비 아이템
            new Item((int)Equipment.OldArmor,(int)EquipmentType.Armor, "낡은 갑옷", true, 0, 5, "어쩌구 저쩌구 갑옷입니다.", 500),
            new Item((int)Equipment.OldShoes,(int)EquipmentType.Shoes, "낡은 신발", true, 0, 2, "어쩌구 저쩌구 신발입니다.", 500),
            new Item((int)Equipment.OldGloves,(int)EquipmentType.Gloves, "낡은 장갑", true, 1, 1, "어쩌구 저쩌구 장갑입니다.", 500),
            new Item((int)Equipment.OldSword,(int)EquipmentType.Weapon, "낡은 검", true, 5, 0, "어쩌구 저쩌구 검입니다.", 500),

            // 소비 아이템
            new Item((int)ConsumableItem.EasyManaPotion,(int)ConsumableItemType.ManaPotion, "그냥 마나 포션", false, 0, 0, "사용하면 마나를 50 회복합니다.", 100),
            new Item((int)ConsumableItem.EasyHpPotion,(int)ConsumableItemType.HpPotion, "그냥 체력 포션", false, 0, 0, "사용하면 체력을 50 회복합니다.", 100),


              // 장비 아이템
            new Item((int)Equipment.SpartaArmor,(int)EquipmentType.Armor, "스파르타 갑옷", true, 0, 15, "튼튼한 스파르타 갑옷입니다.", 1000),
            new Item((int)Equipment.SpartaShoes,(int)EquipmentType.Shoes, "스파르타 신발", true, 0, 6, "가벼운 스파르타 신발입니다.", 1000),
            new Item((int)Equipment.SpartaGloves,(int)EquipmentType.Gloves, "스파르타 장갑", true, 2, 2, "따뜻한 스파르타 장갑입니다.", 1000),
            new Item((int)Equipment.SpartaSword,(int)EquipmentType.Weapon, "스파르타 도검", true, 15, 0, "강력한 스파르타 도검입니다.", 1000),

            // 소비 아이템
            new Item((int)ConsumableItem.GreatManaPotion,(int)ConsumableItemType.ManaPotion, "훌륭한 마나 포션", false, 0, 0, "사용하면 마나를 100 회복합니다.", 300),
            new Item((int)ConsumableItem.GreatHpPotion,(int)ConsumableItemType.HpPotion, "훌륭한 체력 포션", false, 0, 0, "사용하면 체력을 100 회복합니다.", 300)

        };


        public static readonly List<Item> StoreItems = new List<Item>
        { 
            // 장비 아이템
            new Item((int)Equipment.SpartaArmor,(int)EquipmentType.Armor, "스파르타 갑옷", true, 0, 15, "튼튼한 스파르타 갑옷입니다.", 1000),
            new Item((int)Equipment.SpartaShoes,(int)EquipmentType.Shoes, "스파르타 신발", true, 0, 6, "가벼운 스파르타 신발입니다.", 1000),
            new Item((int)Equipment.SpartaGloves,(int)EquipmentType.Gloves, "스파르타 장갑", true, 2, 2, "따뜻한 스파르타 장갑입니다.", 1000),
            new Item((int)Equipment.SpartaSword,(int)EquipmentType.Weapon, "스파르타 도검", true, 15, 0, "강력한 스파르타 도검입니다.", 1000),

            // 소비 아이템
            new Item((int)ConsumableItem.GreatManaPotion,(int)ConsumableItemType.ManaPotion, "훌륭한 마나 포션", false, 0, 0, "사용하면 마나를 100 회복합니다.", 300),
            new Item((int)ConsumableItem.GreatHpPotion,(int)ConsumableItemType.HpPotion, "훌륭한 체력 포션", false, 0, 0, "사용하면 체력을 100 회복합니다.", 300)
        };


        public static Item GetItemById(int id)  // id 검색
        {
            return Items.Find(item => item.id == id);
        }

        // 휴식
        public const int RestHealAmount = 100;
        public const int RestGoldCost = 500;


        // 던전
        public static readonly List<DungeonInfo> dungeons = new List<DungeonInfo>
        {
            new DungeonInfo((int)DungeonMenuOption.EasyDungeon, "쉬운 던전", 5,5,10, 1000),
            new DungeonInfo((int)DungeonMenuOption.NormalDungeon,"일반 던전", 11,11,20, 1700),
            new DungeonInfo((int) DungeonMenuOption.HardDungeon, "어려운 던전", 17,17,30, 2500)
        };
        public static DungeonInfo GetDungeonById(int id)
        {
            return dungeons.FirstOrDefault(dun => dun._id == id);
        }

    }
}
