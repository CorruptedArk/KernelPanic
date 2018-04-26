using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernalPanic
{
    class Customer
    {
        private int id;
        private string name;
        private string street;
        private string city;
        private string state;
        private int zip;
        private int priorityOne;
        private int priorityTwo;
        private int priorityThree;
        private int priorityFour;
        private int priorityFive;
        private int prioritySix;
        private int prioritySeven;

        public int Id { get { return id; } set { id = value; } }

        public string Name { get { return name; } set { name = value; } }
        public string Street { get { return street; } set { street = value; } }
        public string City { get { return city; } set { city = value; } }
        public string State { get { return state; } set { state = value; } }
        public int Zip { get { return zip; } set { zip = value; } }
        public int PriorityOne { get { return priorityOne; }  set { priorityOne = value; } }
        public int PriorityTwo { get { return priorityTwo; }  set { priorityTwo = value; } }
        public int PriorityThree { get { return priorityThree; } set { priorityThree = value; } }
        public int PriorityFour { get { return priorityFour; }  set { priorityFour = value; } }
        public int PriorityFive { get { return priorityFive; } set { priorityFive = value; } }
        public int PrioritySix { get { return prioritySix; } set { prioritySix = value; } }
        public int PrioritySeven { get { return prioritySeven; } set { prioritySeven = value; } }
    }
}
