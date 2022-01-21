using Microsoft.AspNetCore.Mvc;
using Wordle.Interface;

namespace Wordle.Controllers.Wordle
{
    [Route("api/[controller]")]
    public class WordleController : ControllerBase
    {
        private IWordleService wordleService;

        public WordleController(IWordleService wordleService)
        {
            this.wordleService = wordleService;
        }

        // GET: api/<WordleController>
        [HttpGet]
        public IActionResult Get()
        {
            string response = this.wordleService.GenerateWord();
            return Ok(response);
        }
    }
}
