using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonThings;
using Microsoft.Extensions.Logging;

namespace Task4_ParserForFiles
{
    public class CounterRowInText : FounderRowInText
    {
        #region Fields
        private int _rowInText;
        private int _partSize;
        private int _currentPart;
        #endregion

        #region Constructors

        public CounterRowInText(IServiceProvider provider, ILogger<FounderRowInText> logger) : base(provider, logger)
        { }

        #endregion


        public override bool CountOfRowInText(string row, out int count)
        {
            bool outText = false;

            _rowInText = 0;
            RowSize = row.Length;
            _partSize = RowSize * 2;

            Row = row;

            CountOfThread = (int)Math.Floor((double)TextSize / _partSize);

            Parallel.For(0, CountOfThread, (int textPartNumber) =>
            {
                GetCountofRowInPart(textPartNumber);
            });

            count = _rowInText;

            if (count != 0)
            {
                outText = true;
            }
            return outText;
        }

        public override string GetNewFilePath(string textPath)
        {
            return null;
        }

        private void GetCountofRowInPart(int textPartNumber)
        {
            bool _isInText;
            bool _isInTextInEnd = false;
            int _range = textPartNumber * _partSize;
            int accuracy = (RowSize > 1000) ? (16) : ((RowSize > 100) ? 8 : 4);

            lock (this)
            {
                try
                {
                    StringBuilder _builder = new StringBuilder(Text.Substring(_range, _partSize));
                    string _textPart = _builder.ToString();//takes part of text for work in thread

                    string rowPart1 = Row.Substring(0, accuracy);
                    string rowPart2 = Row.Substring(RowSize - accuracy);

                    //find do we have start and end in the part of text
                    _isInText = _textPart.Contains(rowPart1);
                    _isInTextInEnd = _textPart.Contains(rowPart2);

                    if (_isInText == true && _isInTextInEnd == true)
                    {
                        //if we have start and end in the text part 
                        _isInText = _textPart.Contains(Row);
                    }
                    else if (_isInText == true)
                    {
                        //if we got only start of row
                        _builder.Append(Text.Substring((textPartNumber + 1) * _partSize, _partSize - accuracy));
                        _textPart = _builder.ToString();
                        _isInText = _textPart.Contains(Row);
                        _currentPart = textPartNumber;
                        Console.WriteLine(_textPart + "\n\n");
                    }
                    else if (_isInTextInEnd == true)
                    {
                        if (_currentPart != textPartNumber - 1)
                        {
                            _builder.Insert(0, Text.Substring((textPartNumber - 1) * _partSize + accuracy, _partSize - accuracy), 1);
                            _textPart = _builder.ToString();
                            _isInText = _textPart.Contains(Row);
                            Console.WriteLine(_textPart + "\n\n");
                        }
                    }
                    else
                    {
                        _isInText = false;
                    }

                    //operation with common variable
                    if (_isInText == true)
                    {
                        _rowInText++;
                    }
                }
                catch (Exception exception)
                {
                    _exeptions.GetException(exception);
                }
            }
        }
    }

}
