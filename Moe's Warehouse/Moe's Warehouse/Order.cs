using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernalPanic
{
    class Order
    {
        private string orderNum;
        private int custID;
        private string custName;
        private string custStreet;
        private string custState;
        private int custZip;
        private string orderDate;

        public string OrderNum { get { return orderNum; }  set { orderNum = value; } }
        public int CustID { get { return custID; } set { custID = value; } }
        public string CustName { get { return custName; } set { custName = value; } }
        public string CustStreet { get { return custStreet; } set { custStreet = value; } }
        public string CustState { get { return custState; } set { custState = value; } }
        public int CustZip { get { return custZip; }  set { custZip = value; } }
        public string OrderDate { get { return orderDate; } set { orderDate = value; } }
    }
}
