using System.IO;

namespace Task6LuckyTickets
{
    public class InputModel
    {
        private string[] _parametors = new string[3];

        public LuckyAlgorithm AlgorithmType { get; set; }
        public int LowLimit { get; set; }
        public int UpLimit { get; set; }      

        public InputModel(string path)
        {
            ReadFile(path);
            AlgorithmType = GetTypeAlgorithm(_parametors[0]);
            LowLimit = int.Parse(_parametors[1]);
            UpLimit = int.Parse(_parametors[2]);
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
    }
}
