using System;

namespace Zupa.Test.Booking.Models
{
    public class Discount
    {
        public bool IsUsed { get; set; }
        public string Name { get; set; }
        public double DiscountRate { get; set; }
    }
}
