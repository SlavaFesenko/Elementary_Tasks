using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary;

namespace Task6HappyTickets
{
    class Program
    {
        static IView _view = new ConsoleView();
        static void Main(string[] args)
        {
            string path = InputFile();

            try
            {
                File.Exists(path);
                Run(path);
            }
            catch (ArgumentException ex)
            {
                _view.ShowErrorMessage(ex.Message);
            }
            catch (Exception ex)
            {
                _view.ShowErrorMessage(ex.Message);
            }
        }

        #region Method

        public static void Run(string path)
        {
            TicketsCollection myTicketsList = new TicketsCollection();

            using (StreamReader sr = new StreamReader(path))
            {
                LuckyTicketType luckyTicketType = GetLuckyTicketType(sr.ReadLine().ToUpper());
                string buffer = sr.ReadLine();

                while (buffer != null)
                {
                    int[] numbers = Validator.ValidateNumberAndReturnArray(buffer);

                    myTicketsList.Add(new Ticket(numbers, luckyTicketType));

                    buffer = sr.ReadLine();
                }

                _view.ShowResult($"Count lucky tickets: { myTicketsList.CountOfLuckyTickets().ToString()}");
            }
        }

        public static LuckyTicketType GetLuckyTicketType(string userType)
        {
            if (userType == "MOSKOW")
                return LuckyTicketType.Moskow;
            else if (userType == "PITER")
                return LuckyTicketType.Piter;
            else
                throw new FormatException("Invalid algorithm type!");
        }

        public static string InputFile()
        {
            Console.WriteLine("Please input source(path+name) file for reading");

            return Console.ReadLine();
        }


        #endregion
    }
}
