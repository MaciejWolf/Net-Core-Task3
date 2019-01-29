using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Domain.Entities
{
    public class Room
    {
        public Room()
        {
            //Calendar = new List<DateTime>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public int Seats { get; set; }

        public ICollection<DateTime> Calendar { get; private set; }
    }
}
