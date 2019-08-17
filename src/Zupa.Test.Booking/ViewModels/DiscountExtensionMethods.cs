namespace Zupa.Test.Booking.ViewModels
{
    public static class DiscountExtensionMethods
    {
        public static Discount ToDiscountViewModel(this Models.Discount discount)
        {
            return new Discount
            {
                Name = discount.Name,
                DiscountRate = discount.DiscountRate,
                Used = discount.Used
            };
        }

        public static Models.Discount ToDiscountOrderModel(this Discount discount)
        {
            return new Models.Discount
            {
                DiscountRate = discount.DiscountRate,
                Name = discount.Name,
                Used = discount.Used
            };
        }
    }
}
