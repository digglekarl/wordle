using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Wordle;
using Wordle.Interface;
using Wordle.Enum;
using Wordle.Model;

namespace WordleTests
{
    public class Tests
    {
        // private Mock<IWordleService> mockService;
        private WordleService service;

        [SetUp]
        public void Setup()
        {
            this.service = new WordleService();
        }

        [TestCase(5)]
        public void GenerateNewWord(int length)
        {
            //Arrange

            //Act
            var word = this.service.GenerateWord(length);

            //Assert
            Assert.That(word.Length, Is.EqualTo(length));
        }

        [TestCaseSource(nameof(IsValid5Letter))]
        [TestCaseSource(nameof(IsValid6Letter))]
        public void IsValidLetter(string word, string guess, int count, List<WordleModel> expected)
        {
            //Arrange

            //Act

            var result = this.service.IsValidAnswer(word, guess, expected);
            int actual = result.Count(kv => kv.Postion == PositionEnum.ExistsInCorrectPos);

            //Assert
            Assert.AreEqual(actual, count);
        }

        private static IEnumerable<object[]> IsValid5Letter()
        {
            var result = new List<WordleModel>()
            {
                new WordleModel { Letter = 'T', Postion = PositionEnum.NotSet, Index = 0 },
                new WordleModel { Letter = 'R', Postion = PositionEnum.NotSet, Index = 1 },
                new WordleModel { Letter = 'A', Postion = PositionEnum.NotSet, Index = 2 },
                new WordleModel { Letter = 'C', Postion = PositionEnum.NotSet, Index = 3 },
                new WordleModel { Letter = 'E', Postion = PositionEnum.NotSet, Index = 4 }
            };

            return new[] { new object[] { "TRUCK", "TRACE", 3, result } };
        }

        private static IEnumerable<object[]> IsValid6Letter()
        {
            var result = new List<WordleModel>()
            {

                new WordleModel { Letter = 'T', Postion = PositionEnum.NotSet, Index = 0 },
                new WordleModel { Letter = 'E', Postion = PositionEnum.NotSet, Index = 1 },
                new WordleModel { Letter = 'N', Postion = PositionEnum.NotSet, Index = 2 },
                new WordleModel { Letter = 'D', Postion = PositionEnum.NotSet, Index = 3 },
                new WordleModel { Letter = 'E', Postion = PositionEnum.NotSet, Index = 4 },
                new WordleModel { Letter = 'R', Postion = PositionEnum.NotSet, Index = 5 }
            };

            return new[] { new object[] { "RENDER", "TENDER", 5, result } };
        }
    }
}