using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanDungeon
{
    public class Item
    {
        public int id { get;  set; }

        public string part { get;  set; }
        public string name { get;  set; }
        public bool isEquipment { get;  set; }

        public int offensive { get; set; } = 0;
        public int defensive { get; set; } = 0;

        public string description { get;  set; }

        public int price {  get;  set; }

        public Item(int id, string part, string name, bool isEquipment, int offensive,int defensive, string description, int price)
        {
            this.id = id;
            this.part = part;
            this.name = name;
            this.isEquipment = isEquipment;
            this.offensive = offensive;
            this.defensive = defensive;
            this.description = description;
            this.price = price;
        }

        public override string ToString()   // 이름을 리스트로 출력
        {
            return name;
        }


    }
}
