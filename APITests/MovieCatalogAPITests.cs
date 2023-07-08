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
            Random rnd = new Random();
            byte[] byteArray = new byte[100];
            rnd.NextBytes(byteArray);

            return new List<Movie>
            {
                new Movie
                {
                    Id = "64954028b90bb3aacd5fd85b",
                    Genre = "Action, Crime, Thriller",
                    MovieLength = "2:00",
                    ReleaseYear = "2023",
                    ThumbnailPic = byteArray,
                    StartTimes = new List<List<string>>()
                    {
                        new List<string>{"20:00", "22:00"},
                        new List<string>{"20:00", "22:00"}
                    },
                    Title = "Title1"
                },
                new Movie
                {
                    Id = "64954028b90bb3aacd5fd85c",
                    Genre = "Comedy",
                    MovieLength = "2:00",
                    ReleaseYear = "2023",
                    ThumbnailPic = byteArray,
                    StartTimes = new List<List<string>>()
                    {
                        new List<string>{"20:00", "22:00"},
                        new List<string>{"20:00", "22:00"}
                    },
                    Title = "Title2"
                },
                new Movie
                {
                    Id = "64954028b90bb3aacd5fd85d",
                    Genre = "Sci-Fi",
                    MovieLength = "2:00",
                    ReleaseYear = "2023",
                    ThumbnailPic = byteArray,
                    StartTimes = new List<List<string>>()
                    {
                        new List<string>{"20:00", "22:00"},
                        new List<string>{"20:00", "22:00"}
                    },
                    Title = "Title3"
                }
            };
        }
    }
}