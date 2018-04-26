using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernalPanic
{
    class BackorderItem
    {
        private string orderNum;
        private int itemId;
        private int reqQty;
        private int backorderQty;

        public string OrderNum { get { return orderNum; } set { orderNum = value; } }
        public int ItemId { get { return itemId; } set { itemId = value; } }
        public int ReqQty { get { return reqQty; } set { reqQty = value; } }
        public int BackorderQty { get { return backorderQty; } set { backorderQty = value; } }
    }
}
