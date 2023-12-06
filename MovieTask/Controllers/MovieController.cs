using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTask.Services;
using MovieTask.Services.Abstract;

namespace MovieTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieGetService _movieGetService;
        private readonly IMovieService _movieService;

        public MovieController(MovieGetService movieGetService, IMovieService movieService)
        {
            _movieGetService = movieGetService;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _movieGetService.GetMovieFromApi();
            var movie = _movieService.GetAll().FirstOrDefault(m => m.Title == result.Title);
            if (movie == null)
            {
                _movieService.Add(result);
            }
            return Ok();
        }


    }
}
