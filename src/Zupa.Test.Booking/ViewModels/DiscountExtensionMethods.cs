namespace Zupa.Test.Booking.ViewModels
{
    public static class DiscountExtensionMethods
    {
        public static Discount ToDiscountViewModel(this Models.Discount discount)
        {
            return new Discount
            {
                ID = discount.ID,
                Name = discount.Name,
                DiscountRate = discount.DiscountRate,
                Used = discount.Used
            };
        }
    }
}
