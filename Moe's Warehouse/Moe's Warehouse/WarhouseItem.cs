using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernalPanic
{
    class WarhouseItem
    {
        private int IDnum;
        private string name;
        private int qty;
        private int section;

        public int ID { get { return IDnum; } set { IDnum = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Qty { get { return qty; } set { qty = value; } }
        public int Section { get { return section; } set { section = value; } }
    }
}
