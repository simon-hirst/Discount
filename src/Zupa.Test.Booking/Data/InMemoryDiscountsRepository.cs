﻿using System;
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
                new Discount { DiscountRate = 0.90, Name = "discount10", Used = false },
                new Discount { DiscountRate = 0.50, Name = "discount50", Used = false },
            };
        }

        public Task<Discount[]> ReadAllAsync()
        {
            return Task.FromResult(_discounts.ToArray());
        }

        public Task<Discount> ReadAsync(string name)
        {
            return Task.FromResult(_discounts.FirstOrDefault(discount => discount.Name == name));
        }

        public Task SetUsedAsync(string name)
        {
            return Task.FromResult(_discounts.First(discount => discount.Name == name).Used = true);
        }

        public Task<bool> HasBeenUsedAsync(string name)
        {
            return Task.FromResult(_discounts.First(discount => discount.Name == name).Used);
        }

        public Task<bool> HasAnyBeenUsedAsync()
        {
            return Task.FromResult(_discounts.FirstOrDefault(discount => discount.Used == true) != null);
        }
    }
}
