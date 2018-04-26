using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernalPanic
{
    class Warehouses
    {
        private int IDnum;
        private string name;
        private string street;
        private string city;
        private string state;
        private int zip;

        public int ID { get { return IDnum; } set { IDnum = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Street { get { return street; } set { street = value; } }
        public string City { get { return city; } set { city = value; } }
        public string State { get { return state; } set { state = value; } }
        public int Zip { get { return zip; } set { zip = value; } }
    }
}
