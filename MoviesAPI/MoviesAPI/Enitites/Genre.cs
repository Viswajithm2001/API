using MoviesAPI.Validations;

namespace MoviesAPI.Enitites
{
    public class Genre
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        [FirstLetterUpperCase]
        public string MovieName { get; set; }
    }
}
