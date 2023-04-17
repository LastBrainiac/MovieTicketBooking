using Microsoft.AspNetCore.Mvc;
using MTBS.BasketAPI.Controllers;
using MTBS.BasketAPI.Models;
using MTBS.BasketAPI.Repository;
using System.Net;

namespace APITests
{
    public class BasketAPITests
    {
        private readonly Mock<IBasketRepository> _basketRepositoryMock;

        public BasketAPITests()
        {
            _basketRepositoryMock = new Mock<IBasketRepository>();
        }

        [Fact]
        public async Task GivenARequest_WhenCallingGetBasketById_ThenAPIReturnsExpectedResponse()
        {
            var fakeId = "basket999";
            var fakeBasket = GetFakeBasket(fakeId);

            _basketRepositoryMock.Setup(p => p.GetBasketAsync(It.IsAny<string>()))
                .ReturnsAsync(await Task.FromResult(fakeBasket));

            var basketController = new BasketController(_basketRepositoryMock.Object);
            var response = await basketController.GetBasketById(fakeId);

            Assert.Equal((response.Result as OkObjectResult).StatusCode, (int)HttpStatusCode.OK);
            Assert.Equal((((ObjectResult)response.Result).Value as CustomerBasket).Id, fakeId);
        }

        [Fact]
        public async Task GivenARequest_WhenCallingSaveBasket_ThenAPIReturnsExpectedResponse()
        {
            var fakeId = "basket999";
            var fakeBasket = GetFakeBasket(fakeId);

            _basketRepositoryMock.Setup(p => p.SaveBasketAsync(It.IsAny<CustomerBasket>()))
                .ReturnsAsync(await Task.FromResult(fakeBasket));

            var basketController = new BasketController(_basketRepositoryMock.Object);
            var response = await basketController.SaveBasket(fakeBasket);

            Assert.Equal((response.Result as OkObjectResult).StatusCode, (int)HttpStatusCode.OK);
            Assert.Equal((((ObjectResult)response.Result).Value as CustomerBasket).Id, fakeId);
        }

        [Fact]
        public async Task GivenARequest_WhenCallingDeleteBasket_ThenAPIReturnsExpectedResponse()
        {
            // Arrange
            var fakeId = "basket999";
            var fakeBasket = GetFakeBasket(fakeId);

            _basketRepositoryMock.Setup(p => p.DeleteBasketAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(true));

            // Act
            var basketController = new BasketController(_basketRepositoryMock.Object);
            var response = await basketController.DeleteBasket(fakeId);

            // Assert
            Assert.Equal((response.Result as OkObjectResult).StatusCode, (int)HttpStatusCode.OK);
            Assert.True((bool)((ObjectResult)response.Result).Value);
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
