﻿using System;
using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    public interface IDiscountsRepository
    {
        Task<Discount> ReadAsync(string name);
        Task SetUsedAsync(string name);
    }
}
