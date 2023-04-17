using Microsoft.AspNetCore.Mvc;
using MTBS.MovieCatalogAPI.Controllers;
using MTBS.MovieCatalogAPI.Models;
using MTBS.MovieCatalogAPI.Services;
using System.Net;

namespace APITests
{
    public class MovieCatalogAPITests
    {
        private readonly Mock<IMovieService> _movieServiceMock;

        public MovieCatalogAPITests()
        {
            _movieServiceMock = new Mock<IMovieService>();
        }

        [Fact]
        public async Task GivenARequest_WhenCallingGetAllMovies_ThenAPIReturnsExpectedResponse()
        {
            var fakeMovies = GetFakeMovieList();

            _movieServiceMock.Setup(p => p.GetAllMoviesAsync())
                .ReturnsAsync(await Task.FromResult(fakeMovies));

            var movieCatalogController = new MoviesController(_movieServiceMock.Object);

            var response = await movieCatalogController.GetAllMovies();

            Assert.Equal((response.Result as OkObjectResult).StatusCode, (int)HttpStatusCode.OK);
            Assert.Equal((((ObjectResult)response.Result).Value as List<Movie>).Count, fakeMovies.Count);
        }

        private List<Movie> GetFakeMovieList()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                },
                new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                },
                new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                }
            };
        }
    }
}