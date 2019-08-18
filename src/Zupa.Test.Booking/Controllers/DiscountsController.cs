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
            var discountModel = await _discountsRepository.ReadAsync(discountText);
            var basketModel = await _basketsRepository.ReadAsync();

            // error handling
            if (discountModel == null) { return NotFound(new JsonResult("Discount doesn't exist.")); }
            if (discountModel.IsUsed) { return BadRequest(new JsonResult("This discount has been used already.")); }
            if (basketModel.DiscountApplied){ return BadRequest(new JsonResult("A discount has already been applied.")); }

            // set the discount and send to view for confirm
            await _discountsRepository.SetUsedAsync(discountModel.Name);
            await _basketsRepository.SetDiscount(discountModel.DiscountRate);
            discountModel = await _discountsRepository.ReadAsync(discountModel.Name);

            return discountModel.ToDiscountViewModel();
        }
    }
}