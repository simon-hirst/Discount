using System.Linq;
using System.Threading.Tasks;
using Zupa.Test.Booking.Models;

namespace Zupa.Test.Booking.Data
{
    /*
    these are the actual data objects in memory, but you can only mess about with them through the interfaces as explained in IBasketsRepository
    internal*, initialised as a service* at "Startup:14", this one 
    */
    internal class InMemoryBasketsRepository : IBasketsRepository
    {
        // set aside memory for a basket object
        private Basket _basket;

        // initialise the basket object
        public InMemoryBasketsRepository()
        {
            _basket = new Basket();
        }

        // read the basket in memory
        public Task<Basket> ReadAsync()
        {
            // shorthand way to write a task* that just returns something, in this case the basket in memory
            return Task.FromResult(_basket);
        }

        // sets basket to an empty one
        public Task ResetBasketAsync()
        {
            return Task.FromResult(_basket = new Basket());
        }


        public Task<Basket> AddToBasketAsync(BasketItem item)
        {
            var items = _basket.Items.ToList();
            items.Add(item);
            _basket.Items = items;

            return Task.FromResult(_basket);
        }
    }
}
