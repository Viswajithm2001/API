using MoviesAPI.Enitites;
using MoviesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MoviesAPI.Filters;
namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    //[ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IRepository _repository;
        public GenresController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [HttpGet("/allgenres")]
        [ServiceFilter(typeof(MyActionFilter))]
        public async Task<ActionResult<List<Genre>>> Get() //same as IActionresult but the return type
        {
            return await _repository.GetAllGenres();//async method return await
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var genre = await _repository.GetGenreById(id);
            if(genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }
        [HttpGet("details")]
        public IActionResult Get(int id, [FromQuery]string param = null)
        {
            var genre = _repository.GetGenreById_forGetting(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }
        [HttpPost]
        public ActionResult Post([FromBody]Genre genre)
        {
            if (genre == null)
            {
                return BadRequest("Genre cannot be null.");
            }
            else
            {
                if (_repository.HasGenre(genre))
                {
                    return BadRequest($"A genre with Id {genre.Id} already exists.");
                }
                else
                {
                    _repository.AddGenre(genre);
                    return Ok();
                }
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Genre updatedGenre)
        {
            var existingGenre = _repository.GetGenreById_forGetting(id);
            if (existingGenre == null)
            {
                return NotFound();
            }

            existingGenre.Name = updatedGenre.Name;
            existingGenre.MovieName = updatedGenre.MovieName;
            return Ok(existingGenre);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingGenre = await _repository.GetGenreById(id);
            if(existingGenre == null)
            {
                return NotFound();
            }
            _repository.DeleteGenre(id);
            return Ok(existingGenre);
        }
    }
}
