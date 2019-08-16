namespace Zupa.Test.Booking.ViewModels
{
    public static class DiscountExtensionMethods
    {
        public static Discount ToDiscountViewModel(this Models.Discount discount)
        {
            return new Discount
            {
                ID = discount.ID
            };
        }

        public static Models.Discount ToDiscountOrderModel(this Discount discount)
        {
            return new Models.Discount
            {
                ID = discount.ID
            };
        }
    }
}
