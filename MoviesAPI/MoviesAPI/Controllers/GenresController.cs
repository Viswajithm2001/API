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
        public async Task<ActionResult> Post([FromBody]Genre genre)
        {
            if (genre == null)
            {
                return BadRequest("Genre cannot be null.");
            }
            else
            {
                context.Add(genre);
                await context.SaveChangesAsync();
                return Ok(genre);
            }
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
