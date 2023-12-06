using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTask.Services;
using MovieTask.Services.Abstract;
using System.ComponentModel;

namespace MovieTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieGetService movieGetService;
        private readonly IMovieService _movieService;

        public MovieController(MovieGetService movieGetServices, IMovieService movieService)
        {
            movieGetService = movieGetServices;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int waitTimeInSeconds = 5;

            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(waitTimeInSeconds));
                var result = await movieGetService.GetMovieFromApi();
                var movie = _movieService.GetAll().FirstOrDefault(m => m.Title == result.Title);
                if (movie == null)
                {
                    _movieService.Add(result);
                }
            }
        }

    }
}