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
        public List<int> ChangedParts { get => changedParts;}

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


            var result = Parallel.For(0, CountOfThread, (int textPartNumber) =>
              {
                  GetPointWhereChangeText(textPartNumber, rowPart1, rowPart2, accuracy);

                  //Console.WriteLine(Thread.GetCurrentProcessorId());
              });
            Console.WriteLine(DateTime.Now);

            count = _rowInText;
            if (count != 0)
            {
                outText = true;
            }
            return outText;
        }

        public bool NewFileWithNewRows(List<int> forChangeParts, string newRow, string oldRow, string pathNewFile)
        {
            bool succesResult = false;
            int _listCount = forChangeParts.Count;
            pathNewFile = null;

            forChangeParts.Sort();

            using (StreamWriter writer = new StreamWriter(pathNewFile))
            {
                StringBuilder text = new StringBuilder(Text);
                StringBuilder worker = new StringBuilder();
                StringBuilder _forOut = null;

                for (int i = 0; i <= _listCount - 1; i++)
                {
                    worker = text;
                    worker.Remove((int)forChangeParts[i], (int)ChangedParts[i + 1]);

                    if (i != 0)
                    {
                        worker.Replace(oldRow, newRow);
                    }
                    _forOut.Append(worker);
                }

                text.Remove(forChangeParts[_listCount - 1], Text.Length);
                text.Replace(oldRow, newRow);
                _forOut.Append(text);

                writer.WriteAsync(_forOut.ToString());
            }

            return succesResult;
        }

        public void GetPointWhereChangeText(int textPartNumber, string rowPart1, string rowPart2, int accuracy)
        {
            bool _isInText;
            bool _isInTextInEnd = false;
            List<int> points = new List<int>();
            points.Add(0);


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
                        points.AddToChangedList(_textPart, Row, _range);
                    }
                    else if (_isInText == true)
                    {
                        //if we got only start of row
                        _range = (textPartNumber + 1) * _partSize;

                        _builder.Append(Text.Substring(_range, _partSize - accuracy));
                        _textPart = _builder.ToString();
                        //_currentPart = textPartNumber;

                        points.AddToChangedList(_textPart, Row, _range);
                    }
                    else if (_isInTextInEnd == true)
                    {
                        if (!ChangedParts.Contains(textPartNumber - 1))
                        {
                            _range = (textPartNumber - 1) * _partSize + accuracy;
                            _builder.Insert(0, Text.Substring((textPartNumber - 1) * _partSize + accuracy, _partSize - accuracy), 1);
                            _textPart = _builder.ToString();

                            points.AddToChangedList(_textPart, Row, _range);
                        }
                    }
                    else
                    {
                        _isInText = false;
                    }
                }
                //operation with common variable
                if (_isInText == true)
                {
                    _rowInText++;
                }
            }
            catch (Exception exception)
            {
                //add to log
            }

            changedParts = points;
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
