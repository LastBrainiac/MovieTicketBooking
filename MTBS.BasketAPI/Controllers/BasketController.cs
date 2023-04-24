using EventBusBase.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MTBS.BasketAPI.EventBusIntegration.Events;
using MTBS.BasketAPI.Models;
using MTBS.BasketAPI.Repository;

namespace MTBS.BasketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IEventBus _eventBus;

        public BasketController(IBasketRepository basketRepository, IEventBus eventBus)
        {
            _basketRepository = basketRepository;
            _eventBus = eventBus;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> SaveBasket([FromBody] CustomerBasket basket)
        {
            var savedBasket = await _basketRepository.SaveBasketAsync(basket);
            return Ok(savedBasket);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket(string id)
        {
            return Ok(await _basketRepository.DeleteBasketAsync(id));
        }

        [HttpPost("checkout")]
        public async Task<ActionResult> CheckoutBasket([FromBody] CheckoutBasket checkoutBasket)
        {
            var basket = await _basketRepository.GetBasketAsync(checkoutBasket.BasketId);

            if (basket == null)
            {
                return BadRequest();
            }

            var eventMessage = new UserFinishedBookingIntegrationEvent(checkoutBasket.FullName, checkoutBasket.EmailAddress, checkoutBasket.PhoneNumber, basket);

            _eventBus.Publish(eventMessage);

            return Accepted();
        }
    }
}
