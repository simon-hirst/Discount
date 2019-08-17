using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zupa.Test.Booking.Data;
using Zupa.Test.Booking.ViewModels;

namespace Zupa.Test.Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountsRepository _discountsRepository;
        private readonly IBasketsRepository _basketsRepository;

        public DiscountsController(IDiscountsRepository discountsRepository)
        {
            _discountsRepository = discountsRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Discount>> ApplyDiscount([FromBody] Discount discount)
        {
            

            return discount;
        }

        [HttpGet("{discountText}")]
        public async Task<ActionResult<Discount>> GetDiscount(string discountText)
        {
            var discountResult = await _discountsRepository.ReadAsync(discountText);
            return discountResult == null ? null : discountResult.ToDiscountViewModel();
        }
    }
}