﻿using System.Collections.Generic;

namespace Zupa.Test.Booking.ViewModels
{
    public class Basket
    {
        public IEnumerable<BasketItem> Items { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
        public bool DiscountApplied { get; set; }
    }
}
