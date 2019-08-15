using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    internal class InMemoryDiscountsRepository : IDiscountsRepository
    {
        private readonly List<Discount> _discounts;

        public InMemoryDiscountsRepository()
        {
            _discounts = new List<Discount> {
                new Discount { ID = new Guid("7AA533AA-560C-418B-8C2C-EEC8FCDB35EE"), DiscountRate = 0.10, Name = "discount10", Used = false },
                new Discount { ID = new Guid("D86F8A0C-2B6F-41A6-B124-3D2EAE60746D"), DiscountRate = 0.50, Name = "discount50", Used = false },
            };
        }

        public Task<Discount[]> ReadAllAsync()
        {
            return Task.FromResult(_discounts.ToArray());
        }

        public Task<Discount> ReadAsync(Guid id)
        {
            return Task.FromResult(_discounts.First(discount => discount.ID == id));
        }

        public Task SetUsedAsync(Guid id)
        {
            return Task.FromResult(_discounts.First(discount => discount.ID == id).Used = true);
        }

        public Task<bool> HasBeenUsedAsync(Guid id)
        {
            return Task.FromResult(_discounts.First(discount => discount.ID == id).Used);
        }
    }
}
