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

        public string PosterPath { get; set; }
    }

    public class GenreCreationDTO
    {
        public string Name { get; set; }

        public string MovieName { get; set; }

        [FileSizeValidator(1024 * 1024)]
        [FileExtensionValidator(new string[] { ".jpg", ".png", ".jpeg" })] // only these formats are allowed
        public IFormFile Poster { get; set; }  // This will handle the file upload
    }
}
