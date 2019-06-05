using System.Collections.Generic;
using System.IO;

namespace Task4_ParserForFiles
{
    interface ChangePart
    {
        bool CountOfRow(string oldRow, string newRow, out int count);
        bool NewFileWithNewRows(List<int> forChangeParts, string newRow, string oldRow, string pathNewFile);
        void GetPointWhereChangeText(int textPartNumber, string rowPart1, string rowPart2, int accuracy);
        string GetNewFilePath(string textPath);
    }

}
