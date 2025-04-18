using MoviesAPI.Enitites;

namespace MoviesAPI.Services
{
    public interface IRepository
    {
        Task<List<Genre>> GetAllGenres();
        Task<Genre> GetGenreById(int id);
        List<Genre> AddGenre(Genre genre);
        Genre GetGenreById_forGetting(int id);
        bool DeleteGenre(int id);
        bool HasGenre(Genre genre);
    }
}
