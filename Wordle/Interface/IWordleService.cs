using System;
using System.Collections.Generic;
using System.Text;
using Wordle.Enum;
using Wordle.Model;

namespace Wordle.Interface
{
    public interface IWordleService
    {
        string GenerateWord(int len);
        List<WordleModel> IsValidAnswer(string word, string guess, List<WordleModel> letters);
    }
}
