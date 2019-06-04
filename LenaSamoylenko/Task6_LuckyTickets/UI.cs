using System;
using CommonThings;
using CommonThings.AbstractClasses;

namespace Task6_LuckyTickets
{
    class UI : BaseUI, IUAForTask6
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

        public override string CalculateOK()
        {
            throw new NotImplementedException();
        }

        public override string PrintIntoConsole()
        {
            throw new NotImplementedException();
        }
    }
}
