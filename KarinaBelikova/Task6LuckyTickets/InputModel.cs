using System;
using System.IO;

namespace Task6LuckyTickets
{
    public class InputModel
    {
        private string[] _parametors = new string[Constants.INSTRUCTION_PARAMS_COUNT];
        public string _path = string.Empty;

        #region Props

        public LuckyAlgorithm AlgorithmType { get; set; }
        public int LowLimit { get; set; }
        public int UpLimit { get; set; }


        #endregion

        #region Ctor

        public InputModel(string[] args)
        {
            _path = GetPath(args);
            ReadFile(_path);
            AlgorithmType = GetTypeAlgorithm(_parametors[0]);
            LowLimit = int.Parse(_parametors[1]);
            UpLimit = int.Parse(_parametors[2]);
        }

        #endregion

        #region Methods

        private string GetPath(string[] args)
        {
            if (args.Length == 1)
            {
                if (Validator.IsPathValid(args[0]))
                {
                    _path = args[0];
                }
                else
                {
                    UI.ShowInctructions();
                    _path = UI.GetPath();
                }
            }
            else
            {
                UI.ShowInctructions();
                _path = UI.GetPath();
            }

            return _path;
        }


        private void ReadFile(string path)
        {
            using (StreamReader stream = new StreamReader(path))
            {
                for (int i = 0; i < _parametors.Length; i++)
                {
                    _parametors[i] = stream.ReadLine();
                }
            }
        }

        private static LuckyAlgorithm GetTypeAlgorithm(string type)
        {
            LuckyAlgorithm algorithm;
            if (type == "Piter")
            {
                algorithm = new PiterAlgorithm();
            }
            else if (type == "Moscow")
            {
                algorithm = new PiterAlgorithm();
            }
            else
            {
                algorithm = null;
                UI.InvalidFileInstruction();
            }

            return algorithm;
        }

        #endregion

    }
}
