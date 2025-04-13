using MoviesAPI.Enitites;
using MoviesAPI.Services;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<Genre>> Get() //same as IActionresult but the return type
        {
            return _repository.GetAllGenres();
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var genre = _repository.GetGenreById(id);
            if(genre == null)
            {

            }
            return Ok(genre);
        }
        [HttpPost]
        public void Post()
        {

        }
        [HttpPut]
        public void Put()
        {

        }
        [HttpDelete]
        public void Delete()
        {
             
        }
    }
}
