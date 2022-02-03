using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wordle.Controllers.Wordle.Request
{
    public class WordleRequest
    {
        public string Guess { get; set; }
        public string Word { get; set; }
    }
}
