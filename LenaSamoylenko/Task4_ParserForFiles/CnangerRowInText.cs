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
        private SortedDictionary<int, int> changedParts = null;
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

        #endregion

        #region Methods

        public bool GetNewFile(string oldRow, string newRow, out int count, string filePath)
        {
            _rowInText = 0;
            Row = oldRow;
            RowSize = oldRow.Length;
            _partSize = RowSize * 2;
            NewRow = newRow;
            changedParts = new SortedDictionary<int, int>();

            int accuracy = (RowSize > 1000) ? (16) : ((RowSize > 100) ? 8 : 4);

            string rowPart1 = Row.Substring(0, accuracy);
            string rowPart2 = Row.Substring(RowSize - accuracy);
            bool outText = false;

            CountOfThread = (int)Math.Floor((double)TextSize / _partSize);

            Console.WriteLine(DateTime.Now);
            //FileStream outStream = new FileStream(filePath, FileMode.OpenOrCreate);


            var result = Parallel.For(0, CountOfThread, (int textPartNumber) =>
              {
                  GetPointWhereChangeText(textPartNumber, rowPart1, rowPart2, accuracy, filePath);

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

        //private void WriteToFile(StringBuilder builder, StreamWriter stream, int range)
        //{
        //    string text = builder.ToString();
        //    WriteToFile(text, stream, range);

        //}
        //private void WriteToFile(string text, StreamWriter stream, int range)
        //{
        //    char[] textChar = text.ToCharArray();
        //    stream.Write(textChar, range, textChar.Length);
        //}

        private void ReplacePart()
        {
            using ( )
            {

            }
            StringWriter stringWriter = new StringWriter();
            StringReader stringReader=new StringReader()
                
        }

        public char[] ChangingSucces(string oldRow, string newRow, string text)
        {
            char[] textOut = Array.Empty<char>();

            textOut = text.Replace(oldRow, newRow).ToCharArray();

            return textOut;
        }

        public void GetPointWhereChangeText(int textPartNumber, string rowPart1, string rowPart2, int accuracy, string filePath)
        {
            bool _isInText;
            bool _isInTextInEnd = false;

            lock (this)
            {
                int _range = textPartNumber * _partSize;

                try
                {
                    StringBuilder _builder = new StringBuilder(Text.Substring(_range, _partSize));
                    string _textPart = _builder.ToString();//takes part of text for work in thread

                    //find do we have start and end in the part of text
                    _isInText = _textPart.Contains(rowPart1);
                    _isInTextInEnd = _textPart.Contains(rowPart2);

                    if (_isInText == true && _isInTextInEnd == true)
                    {
                        //if we have start and end in the text part 
                        _isInText = _textPart.Contains(Row);
                        AddToChangedList(_isInText, _range, _partSize);
                    }
                    else if (_isInText == true)
                    {
                        //if we got only start of row
                        _range = (textPartNumber + 1) * _partSize;

                        _builder.Append(Text.Substring(_range, _partSize - accuracy));
                        _textPart = _builder.ToString();
                        //_currentPart = textPartNumber;

                        _isInText = _textPart.Contains(Row);
                        AddToChangedList(_isInText, _range, _textPart.Length);

                        //Console.WriteLine(_textPart + "\n\n");
                    }
                    else if (_isInTextInEnd == true)
                    {
                        if (!changedParts.ContainsKey(textPartNumber - 1))
                        {
                            _range = (textPartNumber - 1) * _partSize + accuracy;
                            _builder.Insert(0, Text.Substring((textPartNumber - 1) * _partSize + accuracy, _partSize - accuracy), 1);
                            _textPart = _builder.ToString();

                            _isInText = _textPart.Contains(Row);
                            AddToChangedList(_isInText, _range, _textPart.Length);
                            //Console.WriteLine(_textPart + "\n\n");
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
                    //add to log
                }
            }
        }

        //using (StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.Default))
        //              WriteToFile(_builder, sw, _range);


        private void AddToChangedList(bool isInText, int startFromSymbolNumber, int lenght)
        {
            if (isInText == true)
            {
                changedParts.Add(startFromSymbolNumber, lenght);
            }
        }

        public void GetNewFile(string toFile)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
