using System.IO;

namespace Task4_ParserForFiles
{
    interface ChangePart
    {
        bool GetNewFile(string oldRow, string newRow, out int count, string filePath);
        void ChangeTextInText(int textPartNumber, string rowPart1, string rowPart2, int accuracy, string filePath);
    }

}
