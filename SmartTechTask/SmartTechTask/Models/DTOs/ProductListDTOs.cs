using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTechTask.Models.DTOs
{
    public class ProductListDTOs
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Photo { get; set; }

        public string Price { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
