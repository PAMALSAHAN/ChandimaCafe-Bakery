
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.models
{
    public class ShoppingCartItem
    {
        public int id { get; set; }
        public float price { get; set; }
        public float totalAmount { get; set; }
        public int qty { get; set; }
        public string productName { get; set; }
    }
}
