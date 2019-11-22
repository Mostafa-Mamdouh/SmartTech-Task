using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTechTask.Models.DTOs
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(20, ErrorMessage = "Length must be less then 20 characters")]
        public string Name { get; set; }
        public string Photo { get; set; }
        [Required(ErrorMessage = "Product price is required")]
        public double Price { get; set; }
    }
}
