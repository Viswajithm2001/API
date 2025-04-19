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
        private readonly ILogger<GenresController> _logger;
        public GenresController(IRepository repository,ILogger<GenresController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        [HttpGet("list")]
        [HttpGet("/allgenres")]
        [ServiceFilter(typeof(MyActionFilter))]
        public async Task<ActionResult<List<Genre>>> Get() //same as IActionresult but the return type
        {
            _logger.LogInformation("Getting all genres");
            return await _repository.GetAllGenres();//async method return await
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation($"Getting genre with id {id}");
            var genre = await _repository.GetGenreById(id);
            if(genre == null)
            {

            }
            return Ok(genre);
        }
        [HttpGet("details")]
        public IActionResult Get(int id, [FromQuery]string param = null)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
            _logger.LogInformation("Adding a new genre");
            if (genre == null)
            {
                _logger.LogInformation($"genre is null failed to add new genre");
                return BadRequest("Genre cannot be null.");
            }
            else
            {
                if(!ModelState.IsValid)
                {
                    _logger.LogInformation($"failed to add genre model state invalid");
                    return BadRequest(ModelState);
                }
                if (_repository.HasGenre(genre))
                {
                    _logger.LogInformation($"failed to add genre already exist");
                    return BadRequest($"A genre with Id {genre.Id} already exists.");
                }
                else
                {
                    _repository.AddGenre(genre);
                    _logger.LogInformation($"Added genre with id {genre.Id}");
                    return Ok();
                }
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Genre updatedGenre)
        {
            _logger.LogInformation($"Attempt to update genre with id {id}");
            var existingGenre = _repository.GetGenreById_forGetting(id);
            if (existingGenre == null)
            {
                _logger.LogInformation($"failed to update");
                return NotFound();
            }

            existingGenre.Name = updatedGenre.Name;
            existingGenre.MovieName = updatedGenre.MovieName;
            _logger.LogInformation($"Updated genre with id {id}");
            return Ok(existingGenre);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation($"Attempt to delete genre with id {id}"); //log the deletion
            var existingGenre = await _repository.GetGenreById(id);
            if(existingGenre == null)
            {
                _logger.LogInformation($"failed to delete");
                return NotFound();
            }
            _repository.DeleteGenre(id);
            _logger.LogInformation($"Deleted genre with id {id}");
            return Ok(existingGenre);
        }
    }
}
