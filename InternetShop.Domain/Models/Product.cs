using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Domain.Models
{
    public class Product : IIdentifiable  
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
