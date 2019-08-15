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

        public DiscountsController(IDiscountsRepository discountsRepository)
        {
            _discountsRepository = discountsRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> PlaceOrder([FromBody]Basket basket)
        {
            var orderModel = basket.ToOrderModel();
            await _ordersRepository.SaveAsync(orderModel);
            await _basketsRepository.ResetBasketAsync();

            return CreatedAtAction(
                nameof(GetOrder),
                new { orderModel.ID },
                orderModel.ToOrderViewModel());
        }
    }
}