using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernalPanic
{
    class OrderItem
    {
        private string orderNum;
        private int itemID;
        private int quantity;

        public string OrderNum { get { return orderNum; } set { orderNum = value; } }
        public int ItemID { get { return itemID; } set { itemID = value; } }

        public int Quantity { get { return quantity; } set { quantity = value; } }
    }
}
