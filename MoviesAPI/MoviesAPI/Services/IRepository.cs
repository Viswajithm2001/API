using MoviesAPI.Enitites;

namespace MoviesAPI.Services
{
    public interface IRepository
    {
        Task<List<Genre>> GetAllGenres();
        Task<Genre> GetGenreById(int id);
        List<Genre> AddGenre(Genre genre);
        bool HasGenre(Genre genre);
    }
}
