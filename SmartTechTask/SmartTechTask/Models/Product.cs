using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTechTask.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(20, ErrorMessage = "Length must be less then 20 characters")]
        public string Name { get; set; }
        public string Photo { get; set; }
        [Required(ErrorMessage = "Product price is required")]
        public double Price { get; set; }
        public DateTime ? LastUpdated { get; set; }
    }
}
