using System.Collections.Generic;

namespace Northwind.Domain.Entities
{
    public class Territory
    {
        public Territory()
        {
        }

        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }

    }
}
