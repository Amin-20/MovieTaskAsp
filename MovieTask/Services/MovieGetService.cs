using MovieTask.Services.Abstract;
using MovieTask.Services.Concrete;

namespace MovieTask.Services
{
    public class MovieGetService
    {
        private readonly HttpClient httpClient;
        private readonly Random random;
        private readonly IMovieService _movieService;

        public MovieGetService(IMovieService movieService)
        {
            httpClient = new HttpClient();
            random = new Random();
            _movieService = movieService;
        }

        public async Task GetMovieFromApi()
        {
            char randomLetter = (char)('A' + random.Next(26));

            string apiKey = "573749c3";
            string apiUrl = $"https://www.omdbapi.com/?apikey={apiKey}&s={randomLetter}*";

            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                
            }
            else
            {
               
            }
        }
    }
}
