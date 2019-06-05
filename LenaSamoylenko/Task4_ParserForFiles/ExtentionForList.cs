using System.Collections;
using System.Collections.Generic;

namespace Task4_ParserForFiles
{
    public static class ExtentionForList
    {
        public static void AddToChangedList<T>(this List<T> sl, string _textPart, string Row, T startFromSymbolNumber)
        {
            bool _isInText = _textPart.Contains(Row);

            if (_isInText == true)
            {
                sl.Add(startFromSymbolNumber);
            }
        }
    }
}
