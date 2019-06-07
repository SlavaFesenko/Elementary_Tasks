using System.Collections.Generic;

namespace Task4_ParserForFiles
{
    interface IRowFounder
    {
        bool CountOfRowInText(string oldRow, out int count);
        string GetNewFilePath(string textPath);
        void NewFileWithNewRows(List<int> forChangeParts, string newRow, string oldRow, string pathNewFile);

    }

}
