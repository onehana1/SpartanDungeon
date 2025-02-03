using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanDungeon
{
    public class Item
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public bool isEquipment { get; private set; }

        public int offensive { get; set; } = 0;
        public int defensive { get; set; } = 0;

        public string description { get; private set; }

        public Item(int id, string name, bool isEquipment)
        {
            this.id = id;   //일단 부위
            this.name = name;
            this.isEquipment = isEquipment;
            this.offensive = offensive;
            this.defensive = defensive;
            this.description = description;
        }

        public override string ToString()   // 이름을 리스트로 출력
        {
            return name;
        }


    }
}
