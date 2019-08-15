using System;

namespace Zupa.Test.Booking.Models
{
    public class Discount
    {
        public Guid ID { get; set; }
        public bool Used { get; set; }
        public string Name { get; set; }
        public double DiscountRate { get; set; }
    }
}
