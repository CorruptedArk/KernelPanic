using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernalPanic
{
    class Employees
    {
        private int IDnum;
        private string name;
        private string email;
        private int admin;

        public int ID { get { return IDnum; } set { IDnum = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Email { get { return email; } set { email = value; } }
        public int Admin { get { return admin; } set { admin = value; } }
    }
}
