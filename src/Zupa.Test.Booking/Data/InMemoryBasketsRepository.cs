﻿using System.Linq;
using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    internal class InMemoryBasketsRepository : IBasketsRepository
    {
        private Basket _basket;

        public InMemoryBasketsRepository()
        {
            _basket = new Basket
            {
                Discount = 1
            };
        }

        public Task<Basket> ReadAsync()
        {
            return Task.FromResult(_basket);
        }

        public Task ResetBasketAsync()
        {
            return Task.FromResult(_basket = new Basket
            {
                Discount = 1
            });
        }


        public Task<Basket> AddToBasketAsync(BasketItem item)
        {
            var items = _basket.Items.ToList();
            items.Add(item);
            _basket.Items = items;

            return Task.FromResult(_basket);
        }

        public Task<Basket> SetDiscount(double discountRate)
        {
            _basket.Discount = discountRate;
            _basket.DiscountApplied = true;
            return Task.FromResult(_basket);
        }
    }
}
