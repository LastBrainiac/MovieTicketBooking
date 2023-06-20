using AutoMapper;
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
        private readonly Mock<IMapper> _mapperMock;

        public MovieCatalogAPITests()
        {
            _movieServiceMock = new Mock<IMovieService>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task GivenARequest_WhenCallingGetAllMovies_ThenAPIReturnsExpectedResponse()
        {
            var fakeMovies = GetFakeMovieList();

            _movieServiceMock.Setup(p => p.GetAllMoviesAsync())
                .ReturnsAsync(await Task.FromResult(fakeMovies));

            var movieCatalogController = new MoviesController(_movieServiceMock.Object, _mapperMock.Object);

            var response = await movieCatalogController.GetAllMovies();

            Assert.Equal((int)HttpStatusCode.OK, (response.Result as OkObjectResult).StatusCode);
        }

        private List<Movie> GetFakeMovieList()
        {
            return new List<Movie>
            {
                new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                    Genre = "Action, Crime, Thriller",
                    MovieLength = "2:00",
                    ReleaseYear = "2023",
                    ThumbnailPic = Array.Empty<byte>(),
                    StartTimes = new List<List<string>>()
                    {
                        new List<string>{"20:00", "22:00"},
                        new List<string>{"20:00", "22:00"}
                    },
                    Title = "Title"
                },
                new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                    Genre = "Action, Crime, Thriller",
                    MovieLength = "2:00",
                    ReleaseYear = "2023",
                    ThumbnailPic = Array.Empty<byte>(),
                    StartTimes = new List<List<string>>()
                    {
                        new List<string>{"20:00", "22:00"},
                        new List<string>{"20:00", "22:00"}
                    },
                    Title = "Title"
                },
                new Movie
                {
                    Id = Guid.NewGuid().ToString(),
                    Genre = "Action, Crime, Thriller",
                    MovieLength = "2:00",
                    ReleaseYear = "2023",
                    ThumbnailPic = Array.Empty<byte>(),
                    StartTimes = new List<List<string>>()
                    {
                        new List<string>{"20:00", "22:00"},
                        new List<string>{"20:00", "22:00"}
                    },
                    Title = "Title"
                }
            };
        }
    }
}