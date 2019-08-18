﻿using System.Collections.Generic;

namespace Zupa.Test.Booking.Models
{
    public class Basket
    {
        public IEnumerable<BasketItem> Items { get; set; } = new List<BasketItem>();
        public double Total { get; set; }
        public double Discount { get; set; }
    }
}
