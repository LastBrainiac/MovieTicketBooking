using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MTBS.BasketAPI.Controllers;
using MTBS.BasketAPI.Models;
using MTBS.BasketAPI.Models.DTOs;
using MTBS.BasketAPI.Repository;
using MTBS.EventBus;
using System.Net;

namespace APITests
{
    public class BasketAPITests
    {
        private readonly Mock<IBasketRepository> _basketRepositoryMock;
        private readonly Mock<IRabbitMQMessageSender> _eventBusMock;
        private readonly Mock<IConfiguration> _configurationMock;

        public BasketAPITests()
        {
            _basketRepositoryMock = new Mock<IBasketRepository>();
            _eventBusMock = new Mock<IRabbitMQMessageSender>();
            _configurationMock = new Mock<IConfiguration>();
        }

        [Fact]
        public async Task GivenARequest_WhenCallingGetBasketById_ThenAPIReturnsExpectedResponse()
        {
            var fakeId = "basket999";
            var fakeBasket = GetFakeBasket(fakeId);

            _basketRepositoryMock.Setup(p => p.GetBasketAsync(It.IsAny<string>()))
                .ReturnsAsync(await Task.FromResult(fakeBasket));

            var basketController = new BasketController(_basketRepositoryMock.Object, _eventBusMock.Object, _configurationMock.Object);
            var response = await basketController.GetBasketById(fakeId);

            Assert.Equal((int)HttpStatusCode.OK, (response.Result as OkObjectResult).StatusCode);
            Assert.Equal(fakeId, (((ObjectResult)response.Result).Value as CustomerBasket).Id);
        }

        [Fact]
        public async Task GivenARequest_WhenCallingSaveBasket_ThenAPIReturnsExpectedResponse()
        {
            var fakeId = "basket999";
            var fakeBasket = GetFakeBasket(fakeId);

            _basketRepositoryMock.Setup(p => p.SaveBasketAsync(It.IsAny<CustomerBasket>()))
                .ReturnsAsync(await Task.FromResult(fakeBasket));

            var basketController = new BasketController(_basketRepositoryMock.Object, _eventBusMock.Object, _configurationMock.Object);
            var response = await basketController.SaveBasket(fakeBasket);

            Assert.Equal((int)HttpStatusCode.OK, (response.Result as OkObjectResult).StatusCode);
            Assert.Equal(fakeId, (((ObjectResult)response.Result).Value as CustomerBasket).Id);
        }

        [Fact]
        public async Task GivenARequest_WhenCallingDeleteBasket_ThenAPIReturnsExpectedResponse()
        {
            // Arrange
            var fakeId = "basket999";
            var fakeBasket = GetFakeBasket(fakeId);

            _basketRepositoryMock.Setup(p => p.DeleteBasketAsync(It.IsAny<string>()))
                .ReturnsAsync(await Task.FromResult(true));

            // Act
            var basketController = new BasketController(_basketRepositoryMock.Object, _eventBusMock.Object, _configurationMock.Object);
            var response = await basketController.DeleteBasket(fakeId);

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (response.Result as OkObjectResult).StatusCode);
            Assert.True((bool)((ObjectResult)response.Result).Value);
        }

        [Fact]
        public async Task GivenARequest_WhenCallingCheckoutBasket_ThenAPIReturnsExpectedResponse()
        {
            var fakeId = "basket999";
            var fakeBasket = GetFakeBasket(fakeId);
            var checkoutBasketDto = new CheckoutBasketDTO
            {
                BasketId = fakeId,
                EmailAddress = "aaa@bbb.com",
                FullName = "John Jack",
                PhoneNumber = "+369999999"
            };

            _basketRepositoryMock.Setup(p => p.GetBasketAsync(It.IsAny<string>()))
                .ReturnsAsync(await Task.FromResult(fakeBasket));

            var basketController = new BasketController(_basketRepositoryMock.Object, _eventBusMock.Object, _configurationMock.Object);
            var response = await basketController.CheckoutBasket(checkoutBasketDto);

            Assert.Equal((int)HttpStatusCode.Accepted, (response as AcceptedResult).StatusCode);
        }

        private CustomerBasket GetFakeBasket(string fakeId)
        {
            return new CustomerBasket(fakeId)
            {
                Id = fakeId,
                Items = new List<BasketItem>()
                {
                    new BasketItem()
                }
            };
        }
    }
}
