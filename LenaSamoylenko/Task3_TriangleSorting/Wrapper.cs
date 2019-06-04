using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Task3_TriangleSorting
{
    public class Wrapper
    {
        #region Fields

        private ILogger<Wrapper> _logger = null;
        protected IExeptionForFirstDemo _exeptions = null;

        #endregion

        private static Dictionary<int, string> _answer = new Dictionary<int, string>
        {
            [1] = "Y",
            [2] = "YES"
        };

        public Wrapper(ILogger<Wrapper> logger)
        {
            _logger = logger;
        }
        public string GetCycle(IExeptionForFirstDemo exceptions)
        {
            bool isContinue = true;
            string _message = null;

            try
            {
                while (isContinue == true)
                {
                    Console.WriteLine();
                    string getAnswer = (Console.ReadLine()).ToUpper();
                    isContinue = (getAnswer == _answer[1] || getAnswer == _answer[2]) ? AddTriangleToCollection() : false;
                }
            }
            catch (Exception exception)
            {
                Exception exceptionFinal = exceptions.GetException(exception);

                _message = "Some problems\n";
                _logger.LogError
                _logger.Error(exceptionFinal, "Stopped program because of exception");
            }

            return _message;
        }

        public static bool AddTriangleToCollection()
        {
            bool result = false;
            Triangle triangle = null;

            Console.WriteLine("Put your data in format <name>, <size1>, <size2>, <size3>");
            string row = Console.ReadLine();

            triangle = Logic.GenerateNewTriangle(row, out result);
            if (result == true)
            {
                _triangles.Add(triangle);
            }

            return result;
        }
    }
}
