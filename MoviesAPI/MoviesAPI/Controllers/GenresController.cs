using MoviesAPI.Enitites;
using MoviesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
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
        public IActionResult Get(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var genre = _repository.GetGenreById(id);
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
        public ActionResult Post()
        {
            return NoContent();
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
