// i will not be looking into libraries (or whatever these are called in C#) at the minute due to time constraints
using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    public interface IBasketsRepository
    {
        Task ResetBasketAsync();
        Task<Basket> ReadAsync();
        Task<Basket> AddToBasketAsync(BasketItem item);
        Task<Basket> SetDiscount(double discountRate);
    }
}
