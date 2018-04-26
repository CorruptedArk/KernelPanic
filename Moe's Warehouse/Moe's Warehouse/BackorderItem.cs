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

        public string OrderNum { get => orderNum; set => orderNum = value; }
        public int ItemId { get => itemId; set => itemId = value; }
        public int ReqQty { get => reqQty; set => reqQty = value; }
        public int BackorderQty { get => backorderQty; set => backorderQty = value; }
    }
}
