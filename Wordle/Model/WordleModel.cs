using System;
using System.Collections.Generic;
using System.Text;
using Wordle.Enum;

namespace Wordle.Model
{
    public class WordleModel
    {
        //Correct, Present, Missing
        public char Letter { get; set; }
        public PositionEnum Postion { get; set; }
        public int Index { get; set; }
    }
}
