using System;
using System.Collections.Generic;
using System.Text;
using CommonThings;
using CommonThings.Interfaces;
using T1_ChessBoard;

namespace Task1_ChessBoard
{
    class UI : BaseUI, IUIForBoard
    {
        private int _height;
        private int _wigth;
        Board board = null;
        private string _instruction = null;

        #region Constuctors

        static UI()
        {

        }

        public UI()
        {
            Console.WriteLine("Hello in task 1\n");
        }

        #endregion

        #region MyRegion

        public void GetSizeOfParameters()
        {
            bool forProcces = true;
            bool res1 = false;
            bool res2 = false;
            string instruction = GiveInstruction();

            while (forProcces)
            {
                Console.WriteLine(instruction);
                Console.WriteLine();

                Console.WriteLine("PUT 1st");
                res1 = AfterValidationHeight(Console.ReadLine());

                Console.WriteLine("PUT 2nd");
                res2 = AfterValidationWeigth(Console.ReadLine());

                forProcces = !(res1 && res2);
            }
        }

        public bool AfterValidationHeight(string height)
        {
            bool result = IsValidData(height, out _height);

            return result;
        }

        public bool AfterValidationWeigth(string weigth)
        {
            bool result = IsValidData(weigth, out _wigth);

            return result;
        }

        public override string CalculateOK()
        {
            string result = null;

            try
            {
                board = new Board(_height, _wigth);
                board.SetFigures('*');
                result = "The board was created succesfuly";
            }
            catch (Exception exception)
            {
                //add

                result = "Ups, some problem";
            }

            return result;
        }

        public override string PrintIntoConsole()
        {
            string result = null;

            board.PrintToConsole();

            return result;
        }

        private bool IsValidData(string inSize, out int outSize)
        {
            bool result = false;


            try
            {
                result = Int32.TryParse(inSize, out outSize);
                if (outSize <= 0)
                {
                    outSize = 0;
                    result = false;
                }

            }
            catch (Exception exception)
            {
                //add to logfile
                throw;
            }

            return result;
        }

        private string GiveInstruction()
        {
            string instruction = null;

            InstructionReader.ReadFromFile(out instruction);

            return instruction;
        }

        #endregion

    }
}
