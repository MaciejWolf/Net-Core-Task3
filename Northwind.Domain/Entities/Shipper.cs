﻿using System.Collections.Generic;

namespace Northwind.Domain.Entities
{
    public class Shipper
    {
        public Shipper()
        {
        }

        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

    }
}
