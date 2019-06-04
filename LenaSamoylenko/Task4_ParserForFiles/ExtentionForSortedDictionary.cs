using System.Collections.Generic;

namespace Task4_ParserForFiles
{
    public static class ExtentionForSortedDictionary
    {
        public static void AddToChangedList(this SortedDictionary<int, int> sd, string _textPart, string Row, int startFromSymbolNumber)
        {
            bool _isInText = _textPart.Contains(Row);

            if (_isInText == true)
            {
                sd.Add(startFromSymbolNumber, _textPart.Length);
            }
        }
    }
}
