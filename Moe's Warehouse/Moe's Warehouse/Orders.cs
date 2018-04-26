using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernalPanic
{
    class Orders
    {
        private int orderNum;
        private string name;
        private string items;
        private string itemQtys;

        public int orderNum { get { return orderNum; } set { orderNum = value; } }
        public int name { get { return name; } set { name = value; } }
        public int items { get { return items; } set { items = value; } }
        public int itemQtys { get { return itemQtys; } set { itemQtys = value; } }


    }
}
