using System.ComponentModel.DataAnnotations;
using MoviesAPI.Validations;

namespace MoviesAPI.Enitites
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        [FirstLetterUpperCase]
        public string MovieName { get; set; }
    }
}
