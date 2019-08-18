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

        public DiscountsController(IDiscountsRepository discountsRepository, IBasketsRepository basketsRepository)
        {
            _discountsRepository = discountsRepository;
            _basketsRepository = basketsRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Discount>> ApplyDiscount([FromBody] Discount discount)
        {
            var discountModel = discount.ToDiscountOrderModel();
            await _discountsRepository.SetUsedAsync(discount.Name); // todo: change to take Discount as parameter
            await _basketsRepository.SetDiscount(discountModel.DiscountRate);
            return discount;
        }

        [HttpGet]
        public async Task<bool> DiscountApplied()
        {
            return await _discountsRepository.HasAnyBeenUsedAsync();
        }

        [HttpGet("{discountText}")]
        public async Task<ActionResult<Discount>> GetDiscount(string discountText)
        {
            var discountResult = await _discountsRepository.ReadAsync(discountText);
            return discountResult == null ? null : discountResult.ToDiscountViewModel();
        }
    }
}