using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task6_LuckyTickets
{
    class ChooseConcreteAlgorithm
    {
        #region Fields

        /// <summary>
        /// "0" for Moskov algorithm, "1" for Piter algorithm
        /// </summary>
        private string[] algorithmsNames = { "Moskov`s", "Piter`s" };
        private long[] borders = new long[2];

        private bool? algorithm;
        private FileStream fileStream;
        private StreamReader streamReader;
        private LuckyTickets luckyTickets;

        #endregion


        #region Constructors

        public ChooseConcreteAlgorithm()
        {
            fileStream = GetFileAdress();
            algorithm = GetAlgorithmType();
        }

        #endregion

        #region Methods

        //add if result false
        public bool IsCountTrue()
        {
            bool result = true;

            if (algorithm == false)
            {
                luckyTickets = new MoskovsLuckyTickets(borders[0], borders[1]);
            }
            else if (algorithm == true)
            {
                luckyTickets = new PitersLuckyTickets(borders[0], borders[1]);
            }
            else
            {
                result = false;
            }

            return result;
        }

        public void PrintCountToConsole()
        {
            var collection = luckyTickets.GetCollectionOfTickets();

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

        }

        public void PrintCollectionToConsole()
        {
            Console.WriteLine(luckyTickets.CountLuckyTickets());
        }

        #endregion



        private FileStream GetFileAdress()
        {
            FileStream stream = null;

            while (stream == null)
            {
                try
                {
                    Console.WriteLine("Put file`s adress to choose algorithm");
                    string adress = Console.ReadLine();
                    stream = new FileStream(adress, FileMode.Open);
                }
                catch (Exception exception)
                {
                    //Add to log file
                    Console.WriteLine(exception.Message);
                }
            }

            return stream;
        }


        private bool? GetAlgorithmType()
        {
            bool? result = null;
            FileStream stream = null;
            string fromFile = null;

            stream = this.GetFileAdress();
            streamReader = new StreamReader(stream);
            fromFile = streamReader.ReadToEnd();

            result = fromFile.Contains(algorithmsNames[0]) ? false : (bool?)null;
            result = fromFile.Contains(algorithmsNames[1]) ? true : (bool?)null;

            return result;
        }
    }
}
