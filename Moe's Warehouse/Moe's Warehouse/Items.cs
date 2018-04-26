using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernalPanic
{
    class Items
    {
        private int IDnum;
        private string name;
        private string desc;
        private string tags;
        private float price;
        private int qty;
        private int venCode;

        public int ID { get { return IDnum; } set { IDnum = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Desc { get { return desc; } set { desc = value; } }
        public string Tags { get { return tags; } set { tags = value; } }
        public float Price { get { return price; } set { price = value; } }
        public int Qty { get { return qty; } set { qty = value; } }
        public int VenCode { get { return venCode; } set { venCode = value; } }
    }
}
