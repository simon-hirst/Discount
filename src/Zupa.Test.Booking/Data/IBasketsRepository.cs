// i will not be looking into libraries (or whatever these are called in C#) at the minute due to time constraints
using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    /*
    these act as interfaces* to the actual data objects in memory to ensure asynchronosity*
    */
    public interface IBasketsRepository
    {
        // here, for example, the ResetBasket method in the actual Baskets data object is accessed via this, NOT directly
        Task ResetBasketAsync();
        Task<Basket> ReadAsync();
        Task<Basket> AddToBasketAsync(BasketItem item);
        Task<Basket> SetDiscount(double discountRate);
    }
}
