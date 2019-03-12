using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Domain.Models
{
    public class Category : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
