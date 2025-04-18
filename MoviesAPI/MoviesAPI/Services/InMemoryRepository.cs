using MoviesAPI.Enitites;

namespace MoviesAPI.Services
{
    public class InMemoryRepository : IRepository
    {
        private List<Genre> _genres;
        public InMemoryRepository()
        {
            _genres = new List<Genre>()
            {
                new Genre(){Id = 1,Name = "Comedy", MovieName = "Super bad"},
                new Genre(){Id = 2,Name = "Action" , MovieName = "Mad Max"},
                new Genre(){Id = 3,Name = "Thriller", MovieName = "conjuring"},
            };
        }
        public async Task<List<Genre>> GetAllGenres()
        {
            await Task.Delay(3000); 
            return _genres;
        }
        public async Task<Genre> GetGenreById(int id)
        {
            await Task.Delay(2000);
            var genre = _genres.FirstOrDefault(x => x.Id == id);
            return genre;
        }
        public List<Genre> AddGenre(Genre genre)
        {
            if(genre == null)
            {
                return _genres;
            }
            _genres.Add(genre);
            return _genres;
        }
        public bool HasGenre(Genre genre)
        {
            if (genre == null)
            {
                return false;
            }
            var existingGenre = _genres.FirstOrDefault(x => x.Id == genre.Id);
            if (existingGenre != null)
            {
                return true;
            }
            return false;
        }
    }
}
