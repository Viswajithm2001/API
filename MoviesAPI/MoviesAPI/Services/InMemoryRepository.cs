using MoviesAPI.Enitites;

namespace MoviesAPI.Services
{
    public class InMemoryRepository : IRepository
    {
        private List<Genre> _genre;
        public InMemoryRepository()
        {
            _genre = new List<Genre>()
            {
                new Genre(){Id = 1,Name = "Comedy"},
                new Genre(){Id = 2,Name = "Action"},
            };
        }
        public List<Genre> GetAllGenres()
        {
            return _genre;
        }
        public Genre GetGenreById(int id)
        {
            return _genre.FirstOrDefault(x => x.Id == id);
        }
    }
}
