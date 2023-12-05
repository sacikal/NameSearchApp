using Microsoft.AspNetCore.Mvc;
using NameSearchApp.Domain;
using NameSearchApp.Services;

namespace NameSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public ActionResult<List<Person>> Get([FromQuery] string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return BadRequest("Please provide a search term");
            }

            var results = _searchService.Search(term);
            return Ok(results);
        }
    }
}