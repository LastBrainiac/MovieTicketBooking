using Microsoft.AspNetCore.Mvc;
using MTBS.BasketAPI.EventBusIntegration.Messages;
using MTBS.BasketAPI.Models;
using MTBS.BasketAPI.Models.DTOs;
using MTBS.BasketAPI.Repository;
using MTBS.EventBus;

namespace MTBS.BasketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IRabbitMQMessageSender _messageSender;
        private readonly IConfiguration _configuration;

        public BasketController(IBasketRepository basketRepository, IRabbitMQMessageSender messageSender, IConfiguration configuration)
        {
            _basketRepository = basketRepository;
            _messageSender = messageSender;
            _configuration = configuration;
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
        public async Task<ActionResult> CheckoutBasket([FromBody] CheckoutBasketDTO checkoutBasket)
        {
            var basket = await _basketRepository.GetBasketAsync(checkoutBasket.BasketId);

            if (basket == null)
            {
                return BadRequest();
            }

            var message = new UserFinishedBooking(checkoutBasket.FullName, checkoutBasket.EmailAddress, checkoutBasket.PhoneNumber, basket);

            _messageSender.PublishMessage(message, _configuration["EventBus:BookingQueueName"]);            

            return Accepted();
        }
    }
}
