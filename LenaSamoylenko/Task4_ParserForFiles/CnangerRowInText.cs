using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Task4_ParserForFiles
{
    public class CnangerRowInText : FounderRowInText
    {
        #region Fields
        private int _rowInText;
        private int _partSize;

        #endregion

        #region Constructors

        public CnangerRowInText(IServiceProvider provider, ILogger<FounderRowInText> logger) : base(provider, logger)
        {
            _servicesProvider = provider;
            _logger = logger;
        }

        #endregion

        #region Methods

        #region PublicMethods

        public override bool CountOfRowInText(string oldRow, out int count)
        {
            _rowInText = 0;
            Row = oldRow;
            RowSize = oldRow.Length;
            _partSize = RowSize * 2;

            _changedParts = new List<int>();
            ChangedParts.Add(TextSize);

            int accuracy = (RowSize > 1000) ? (16) : ((RowSize > 100) ? 8 : 4);

            string rowPart1 = Row.Substring(0, accuracy);
            string rowPart2 = Row.Substring(RowSize - accuracy);
            bool outText = false;

            CountOfThread = (int)Math.Floor((double)TextSize / _partSize);

            //to find 
            var result = Parallel.For(0, CountOfThread, (int textPartNumber) =>
            {
                GetPointWhereChangeText(textPartNumber, rowPart1, rowPart2, accuracy, ref _changedParts);
            });

            _rowInText = ChangedParts.Count - 1;

            count = _rowInText;

            if (count != 0)
            {
                outText = true;
            }
            return outText;
        }

        public override void NewFileWithNewRows(List<int> forChangeParts, string oldRow, string pathNewFilestring, string newRow)
        {
            NewFile(forChangeParts, oldRow, pathNewFilestring, newRow);
        }

        public override string GetNewFilePath(string textPath)
        {
            string outPath = null;
            _logger.LogInformation(20, "Doing hard work! {System.Reflection.MethodBase.GetCurrentMethod().Name}");

            char separartor = Path.DirectorySeparatorChar;
            outPath = textPath.Remove(textPath.LastIndexOf(separartor));
            string fileName = String.Format(@"{0}.txt", System.Guid.NewGuid());
            outPath = String.Concat(outPath, separartor, fileName);

            return outPath;
        }

        #endregion


        private async void NewFile(List<int> forChangeParts, string oldRow, string pathNewFile, string newRow)
        {
            //isSucces = false;
            int _listCount = forChangeParts.Count - 1;

            forChangeParts.Sort();

            try
            {
                using (FileStream stream = new FileStream(pathNewFile, FileMode.OpenOrCreate))
                {
                    StreamWriter writer = new StreamWriter(stream, base.CurrentEncoding);

                    string worker = null;
                    StringBuilder _forOut = new StringBuilder();

                    for (int i = 0; i <= _listCount - 1; i++)
                    {
                        worker = Text;

                        int firstRange = (forChangeParts[i + 1]);
                        int secondRange = TextSize - firstRange;

                        worker = worker.Remove(firstRange, secondRange);
                        worker = worker.Remove(0, (int)(forChangeParts[i]));
                        worker = worker.Replace(oldRow, newRow);

                        _forOut.Append(worker);
                    }

                    worker = Text.Remove(0, forChangeParts[_listCount - 1]);
                    worker = worker.Replace(oldRow, newRow);
                    _forOut.Append(worker);

                    await writer.WriteAsync(_forOut.ToString());
                    stream.Close();

                    Console.WriteLine(pathNewFile);
                }
            }
            catch (Exception exception)
            {
                Exception exceptionFinal = _exeptions.GetException(exception);
                _logger.LogError(exceptionFinal, "Error in method{0}\nmessage:{1}",
                                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                                    exceptionFinal.Message);
            }
        }

        private void GetPointWhereChangeText(int textPartNumber, string rowPart1, string rowPart2, int accuracy, ref List<int> list)
        {
            lock (this)
            {
                bool _isInText;
                bool _isInTextInEnd = false;

                try
                {
                    int _range = textPartNumber * _partSize;
                    StringBuilder _builder = new StringBuilder(Text.Substring(_range, _partSize));

                    //StringWriter reader = new StringWriter()
                    string _textPart = _builder.ToString();//takes part of text for work in thread

                    //find do we have start and end in the part of text
                    _isInText = _textPart.Contains(rowPart1);
                    _isInTextInEnd = _textPart.Contains(rowPart2);

                    if (_isInText == true && _isInTextInEnd == true)
                    {
                        //if we have start and end in the text part 
                        list.AddToChangedList(_textPart, Row, _range);
                    }
                    else if (_isInText == true)
                    {
                        //if we got only start of row
                        var _rangeHelp = (textPartNumber + 1) * _partSize;

                        _builder.Append(Text.Substring(_rangeHelp, _partSize - accuracy));
                        _textPart = _builder.ToString();

                        list.AddToChangedList(_textPart, Row, _range);
                    }
                    else if (_isInTextInEnd == true)
                    {
                        if (!ChangedParts.Contains(textPartNumber - 1))
                        {
                            var _rangeHelper = (textPartNumber - 1) * _partSize + accuracy;
                            _builder.Insert(0, Text.Substring((textPartNumber - 1) * _partSize + accuracy, _partSize - accuracy), 1);
                            _textPart = _builder.ToString();

                            bool _isIn = _textPart.Contains(Row);
                            if (_isIn == true)
                                list.AddToChangedList(_textPart, Row, _rangeHelper + _textPart.IndexOf(Row));
                        }
                    }
                    else
                    {
                        _isInText = false;
                    }

                }

                catch (Exception exception)
                {
                    Exception exceptionFinal = _exeptions.GetException(exception);
                    _logger.LogError(exceptionFinal, "Error in method{0}\nmessage:{1}",
                                        System.Reflection.MethodBase.GetCurrentMethod().Name,
                                        exceptionFinal.Message);
                }
            }
        }
    }

    #endregion
}

