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
                new Genre(){Id = 3,Name = "Thriller"},
            };
        }
        public async Task<List<Genre>> GetAllGenres()
        {
            await Task.Delay(3000); 
            return _genre;
        }
        public async Task<Genre> GetGenreById(int id)
        {
            await Task.Delay(2000);
            return _genre.FirstOrDefault(x => x.Id == id);
        }
    }
}
