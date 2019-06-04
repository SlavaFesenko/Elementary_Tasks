using System;
using CommonThings;

namespace Task6_LuckyTickets
{
    class UA : IUA, IUAForTask6
    {
        ChooseConcreteAlgorithm choose;
        public void PutOK()
        {
            choose = new ChooseConcreteAlgorithm();
            //add isCountTrue

        }

        public void PrintCollection()
        {
            choose.PrintCollectionToConsole();
        }

        public void PrintCount()
        {
            choose.PrintCountToConsole();
        }

        public void SetConsoleSize(int height, int wight)
        {
            throw new NotImplementedException();
        }
    }
}
