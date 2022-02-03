using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Wordle.Controllers.Wordle.Request;
using Wordle.Interface;
using Wordle.Model;

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

        [HttpPost]
        public IActionResult Post([FromBody] WordleRequest request)
        {
            var letters = new List<WordleModel>();
            
            var guess = request.Guess.ToCharArray().ToList();
            guess.RemoveAll(x => x == ',');

            var i = 0;
            guess.ForEach(x =>
            {
                letters.Add(new WordleModel { Index = i, Letter = x, Position = Enum.PositionEnum.NotSet });
                i++;
            });
            
            var answer = this.wordleService.IsValidAnswer(request.Word, request.Guess, letters);
            return Ok(answer);
        }
    }
}
