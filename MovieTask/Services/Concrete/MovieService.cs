using MovieTask.Entities;
using MovieTask.Repositories.Abstract;
using MovieTask.Services.Abstract;

namespace MovieTask.Services.Concrete
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void Add(Movie entity)
        {
            _movieRepository.Add(entity);
        }

        public void Delete(int id)
        {
            var movie = _movieRepository.Get(id);
            _movieRepository.Delete(movie);
        }

        public Movie Get(int id)
        {
            return _movieRepository.Get(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public void Update(Movie entity)
        {
            _movieRepository.Update(entity);
        }
    }
}
