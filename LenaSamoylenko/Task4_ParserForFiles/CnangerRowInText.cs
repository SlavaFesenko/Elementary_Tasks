using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonThings;
using CommonThings;

namespace Task4_ParserForFiles
{
    public class CnangerRowInText : FounderRowInText, ChangePart
    {
        #region Fields
        private string _newRow;
        private readonly Encoding currentEncoding = null;
        private int _rowInText;
        private int _partSize;
        private int _currentPart;
        private List<int> changedParts = null;
        #endregion

        #region Constructors

        internal CnangerRowInText(string textPath) : base(textPath)
        {
            bool isTextReadable = false;
            try
            {
                isTextReadable = InstructionReader.IsCouldGetText(textPath, out string _text, out currentEncoding);
                if (isTextReadable == true)
                {
                    Text = _text;
                    TextSize = _text.Length;
                }

            }
            catch (Exception exception)
            {

                throw;
            }
        }

        #endregion

        #region Properties

        public string NewRow { get => _newRow; private set => _newRow = value; }
        public List<int> ChangedParts { get => changedParts; }

        #endregion

        #region Methods

        public bool CountOfRow(string oldRow, string newRow, out int count)
        {
            _rowInText = 0;
            Row = oldRow;
            RowSize = oldRow.Length;
            _partSize = RowSize * 2;
            NewRow = newRow;
            changedParts = new List<int>();

            int accuracy = (RowSize > 1000) ? (16) : ((RowSize > 100) ? 8 : 4);

            string rowPart1 = Row.Substring(0, accuracy);
            string rowPart2 = Row.Substring(RowSize - accuracy);
            bool outText = false;

            CountOfThread = (int)Math.Floor((double)TextSize / _partSize);

            Console.WriteLine(DateTime.Now);
            //FileStream outStream = new FileStream(filePath, FileMode.OpenOrCreate);

            _rowInText = 0;
            changedParts.Add(TextSize);

            Console.WriteLine(DateTime.Now);

            var result = Parallel.For(0, CountOfThread, (int textPartNumber) =>
              {
                  GetPointWhereChangeText(textPartNumber, rowPart1, rowPart2, accuracy, ref changedParts);

                  //Console.WriteLine(Thread.GetCurrentProcessorId());
              });
            _rowInText = changedParts.Count - 1;
            Console.WriteLine(DateTime.Now);

            count = _rowInText;
            if (count != 0)
            {
                outText = true;
            }
            return outText;
        }

        public async void NewFileWithNewRows(List<int> forChangeParts, string newRow, string oldRow, string pathNewFile)
        {
            //isSucces = false;
            int _listCount = forChangeParts.Count - 1;

            forChangeParts.Sort();
            try
            {
                using (FileStream stream = new FileStream(pathNewFile, FileMode.OpenOrCreate))
                {
                    StreamWriter writer = new StreamWriter(stream);

                    string worker = null;
                    StringBuilder _forOut = new StringBuilder();

                    for (int i = 0; i <= _listCount - 1; i++)
                    {
                        worker = Text;
                        worker = worker.Remove((int)forChangeParts[i]);

                        if (i != 0)
                        {
                            worker = worker.Replace(oldRow, newRow);
                        }
                        _forOut.Append(worker);
                    }

                    worker = Text.Remove(0, forChangeParts[_listCount - 1]);
                    worker = worker.Replace(oldRow, newRow);
                    _forOut.Append(worker);

                    await writer.WriteAsync(_forOut.ToString());
                    stream.Close();

                    Console.WriteLine(_forOut.ToString().Contains(newRow));
                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine(pathNewFile);
                }
            }
            catch (Exception exception)
            {

                throw;
            }


            //return succesResult;
        }

        public void GetPointWhereChangeText(int textPartNumber, string rowPart1, string rowPart2, int accuracy, ref List<int> list)
        {
            bool _isInText;
            bool _isInTextInEnd = false;

            int _range = textPartNumber * _partSize;

            try
            {
                lock (this)
                {
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
                        _range = (textPartNumber + 1) * _partSize;

                        _builder.Append(Text.Substring(_range, _partSize - accuracy));
                        _textPart = _builder.ToString();
                        //_currentPart = textPartNumber;

                        list.AddToChangedList(_textPart, Row, _range);
                    }
                    else if (_isInTextInEnd == true)
                    {
                        if (!ChangedParts.Contains(textPartNumber - 1))
                        {
                            _range = (textPartNumber - 1) * _partSize + accuracy;
                            _builder.Insert(0, Text.Substring((textPartNumber - 1) * _partSize + accuracy, _partSize - accuracy), 1);
                            _textPart = _builder.ToString();

                            list.AddToChangedList(_textPart, Row, _range);
                        }
                    }
                    else
                    {
                        _isInText = false;
                    }
                }
                //operation with common variable



            }
            catch (Exception exception)
            {
                //add to log
            }
        }

        public string GetNewFilePath(string textPath)
        {
            string outPath = null;

            char separartor = Path.DirectorySeparatorChar;
            outPath = textPath.Remove(textPath.LastIndexOf(separartor));
            string fileName = String.Format(@"{0}.txt", System.Guid.NewGuid());
            outPath = String.Concat(outPath, separartor, fileName);

            return outPath;
        }

        #endregion
    }
}
