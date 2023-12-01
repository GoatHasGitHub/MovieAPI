using MovieAPI.Data;

namespace MovieAPI.Services
{
    public class MoviesService
    {
        private AppDbContext _context;
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }
        public void AddMovie(MovieVM movie)
        {
            var newMovie = new Movie()
            {
                Title = movie.Title,
                Genre = movie.Genre,
                Year = movie.Year,
            };
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
        }
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }
        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }
        public Movie UpdateBookById(int id, MovieVM MovieVM)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                movie.Title = MovieVM.Title;
                movie.Genre = MovieVM.Genre;
                movie.Year = MovieVM.Year;
                _context.SaveChanges();
            }
            return movie;
        }

        internal object UpdateMovieById(int id, MovieVM movieVM)
        {
            throw new NotImplementedException();
        }
        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
