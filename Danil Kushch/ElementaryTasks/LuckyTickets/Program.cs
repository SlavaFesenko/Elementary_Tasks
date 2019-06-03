using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LuckyTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "ticketsList1.txt";

            try
            {
                Run(path);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
    
            Console.ReadLine();
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

                UI.Display(myTicketsList);
            }
        }

        public static LuckyTicketType GetLuckyTicketType(string userType)
        {
            if (userType == "MOSKOW")
                return LuckyTicketType.Moskow;
            else if (userType == "PITER")
                return LuckyTicketType.Piter;
            else
                throw new FormatException("Can't understand algorithm type!");
        }

        #endregion
    }
}
