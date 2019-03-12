using System;
using System.Collections.Generic;
using System.Web.Http;

namespace InternetShop.Controllers
{
    public class Order
    {
        public int NumberOrder { get; set; }
        public string Name { get; set; }
    }
    public class OrderController : ApiController
    {
        [NonAction]
        public IEnumerable<Order> GetOrders()
        {
            List<Order> orders = new List<Order>()
            {
                new Order()
                {
                    NumberOrder = 3, Name = "Pinterest"
                },
                new Order()
                {
                    NumberOrder = 4, Name = "Tropicly"
                },
                new Order()
                {
                    NumberOrder = 5, Name = "Gluhovskii"
                }
            };
            return orders;
        }
    }
}
