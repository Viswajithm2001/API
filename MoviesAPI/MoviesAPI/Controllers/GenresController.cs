using MoviesAPI.Enitites;
using MoviesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesAPI.Filters;
namespace MoviesAPI.Controllers
{
    //[Route("[controller]")]
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<GenresController> logger;
        public GenresController(ApplicationDbContext dbContext, ILogger<GenresController> logger)
        {
            context = dbContext;
            this.logger = logger;
        }
        [HttpGet]
        [HttpGet("/allgenres")]
        [ServiceFilter(typeof(MyActionFilter))]
        public async Task<ActionResult<List<Genre>>> Get() //same as IActionresult but the return type
        {
            return await context.Genres.ToListAsync();//async method return await
        }
        [HttpGet("{id:int}")]
        //[HttpGet("{id:int}",Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(x=> x.Id==id);
            if(genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] GenreCreationDTO genreDTO)
        {
            var genre = new Genre
            {
                Name = genreDTO.Name,
                MovieName = genreDTO.MovieName
            };

            if (genreDTO.Poster != null)
            {
                var postersFolder = Path.Combine("wwwroot", "posters");
                var fileName = $"{Guid.NewGuid()}_{genreDTO.Poster.FileName}";
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), postersFolder, fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await genreDTO.Poster.CopyToAsync(stream);
                }

                genre.PosterPath = Path.Combine("posters", fileName).Replace("\\", "/");
            }

            context.Add(genre);
            await context.SaveChangesAsync();

            return Ok(genre);
            //return CreatedAtAction("Get", new { id = genre.Id }, genre);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Genre updatedGenre)
        {
            var existingGenre = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (existingGenre == null)
            {
                return NotFound();
            }

            existingGenre.Name = updatedGenre.Name;
            existingGenre.MovieName = updatedGenre.MovieName;
            existingGenre.PosterPath = updatedGenre.PosterPath;
            await context.SaveChangesAsync();
            return Ok(existingGenre);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingGenre = await context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (existingGenre == null)
            {
                return NotFound();
            }
            context.Genres.Remove(existingGenre);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
