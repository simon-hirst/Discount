using System;
using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    public interface IDiscountsRepository
    {
        Task<Discount[]> ReadAllAsync();
        Task<Discount> ReadAsync(Guid id);
        Task SetUsedAsync(Guid id);
        Task<bool> HasBeenUsedAsync(Guid id);
    }
}
