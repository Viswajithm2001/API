using MoviesAPI.Enitites;
using MoviesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    //[ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IRepository _repository;
        public GenresController(IRepository repository)
        {
            this._repository = repository; 
        }
        [HttpGet]
        [HttpGet("list")]
        [HttpGet("/allgenres")]
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
            var genre = _repository.GetGenreById(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }
        [HttpPost]
        public ActionResult Post([FromBody]Genre genre)
        {
            if(genre == null)
            {
                return BadRequest("Genre cannot be null.");
            }
            else
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
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
        [HttpPut]
        public ActionResult Put()
        {
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
             return NoContent();
        }
    }
}
