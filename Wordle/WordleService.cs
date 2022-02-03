using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Wordle.Enum;
using Wordle.Extension;
using Wordle.Interface;
using Wordle.Model;

namespace Wordle
{
    public class WordleService : IWordleService
    {
        private string[] words = { "bless","range","spoil","great","stain","craft","space","straw","sheep","cabin","brink","screw","sight","troop","ready","loose","south","dirty","wheel","harsh","field","sweet","feast","tribe","truck","sheet","wound","fling","apple","enjoy","skate","trend","orbit","worth","power","awful","raise","judge","tiger","coach","ghost","gaffe","sport","wrist","mayor","share","doubt","punch","major","rumor"};
        private string[] answers = { "" };

        public string GenerateWord(int len)
        {
            Random random = new Random();

            return words[random.Next(0, words.Length)];
        }

        public List<WordleModel> IsValidAnswer(string word, string guess, List<WordleModel> letters)
        {
            var result = new List<WordleModel>();

            foreach (var letter in letters)
            {
                var wordIndex = word.IndexOfAll(letter.Letter.ToString());

                if (wordIndex.Count() == 0)
                {
                    letter.Position = PositionEnum.Absent;
                }
                else
                {
                    if (wordIndex.Any(x => x == letter.Index))
                    {
                        letter.Position = PositionEnum.Correct;
                    }
                    else
                    {
                        letter.Position = PositionEnum.Present;
                    }
                }
            }

            return letters;
        }

    }
}
