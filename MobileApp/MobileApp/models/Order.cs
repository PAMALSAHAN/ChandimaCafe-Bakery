
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.models
{
    class Order
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int OrderTotal { get; set; }
        public DateTime orderPlaced { get; set; }
        public bool isOrderCompleted { get; set; }
        public int UserId { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
