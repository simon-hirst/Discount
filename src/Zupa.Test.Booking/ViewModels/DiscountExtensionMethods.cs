namespace Zupa.Test.Booking.ViewModels
{
    public static class DiscountExtensionMethods
    {
        public static Discount ToDiscountViewModel(this Models.Discount discount)
        {
            return new Discount
            {
                Name = discount.Name
            };
        }
    }
}
