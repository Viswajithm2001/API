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
                new Genre(){Name = "Comedy", MovieName = "Super bad"},
                new Genre(){Name = "Action" , MovieName = "Mad Max"},
                new Genre(){Name = "Thriller", MovieName = "conjuring"},
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
        public Genre GetGenreById_forGetting(int id)
        {
            var genre = _genres.FirstOrDefault(x => x.Id == id);
            return genre;
        }
        public bool DeleteGenre(int id)
        {
            var genre = _genres.FirstOrDefault(x => x.Id == id);
            if (genre != null)
            {
                _genres.Remove(genre);
                return true;
            }
            return false;
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
