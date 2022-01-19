using System;
using System.Collections.Generic;
using System.Text;

namespace Wordle.Enum
{
    public enum PositionEnum
    {
        NotSet = 0,
        ExistsInCorrectPos=1,
        ExistsInWrongPos=2,
        DoesNotExist=3
    }
}
