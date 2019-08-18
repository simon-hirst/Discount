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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Discount>> ApplyDiscount([FromBody] string discountText)
        {
            var discountResult = await _discountsRepository.ReadAsync(discountText);
            var basket = await _basketsRepository.ReadAsync();

            if (discountResult == null) { return NotFound(new JsonResult("Discount doesn't exist.")); }
            if (discountResult.Used) { return BadRequest(new JsonResult("This discount has been used already.")); }
            if (basket.Discount != 1){ return NotFound(new JsonResult("A discount has already been applied.")); }

            await _discountsRepository.SetUsedAsync(discountResult.Name); // todo: change to take Discount as parameter
            await _basketsRepository.SetDiscount(discountResult.DiscountRate);
            discountResult = await _discountsRepository.ReadAsync(discountResult.Name);

            return discountResult.ToDiscountViewModel();
        }
    }
}