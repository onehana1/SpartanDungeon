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

        public Item(int id, string name, bool isEquipment)
        {
            this.id = id;
            this.name = name;
            this.isEquipment = isEquipment;
        }

        public override string ToString()   // 이름을 리스트로 출력
        {
            return name;
        }


    }
}
