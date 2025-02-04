using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanDungeon
{
    public class DungeonInfo
    {
        public int _id;
        public string _name { get; }
        public int rDef { get; }
        public int rOff { get; }

        public int reduceHp { get; }

        public int RewardGold { get; }

        public DungeonInfo(int id, string name, int recDef, int recOff, int redHp, int rewardGold)
        {
            _id = id;
            _name = name;
            reduceHp = redHp;
            this.rDef = recDef;
            this.rOff = recOff;
            RewardGold = rewardGold;
        }
    }
}
