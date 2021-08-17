using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage="Name is required!")]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Phone { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
