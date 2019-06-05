using System.Collections.Generic;
using System.IO;

namespace Task4_ParserForFiles
{
    interface ChangePart
    {
        bool CountOfRow(string oldRow, string newRow, out int count);
        void NewFileWithNewRows(List<int> forChangeParts, string newRow, string oldRow, string pathNewFile);
        void GetPointWhereChangeText(int textPartNumber, string rowPart1, string rowPart2, int accuracy, ref List<int> list);
        string GetNewFilePath(string textPath);
    }

}
