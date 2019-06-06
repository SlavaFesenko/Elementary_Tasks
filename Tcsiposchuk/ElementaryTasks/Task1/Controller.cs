using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class Controller : BaseController
    {
        

        public void Run(string [] args)
        {
            InputModel inputModel = GetInputModel(args);
            RunWithInputModel(inputModel);
        }

        private void RunWithInputModel(InputModel inputModel)
        {
            Board board = new Board(inputModel);
            UI.PrintBoard(board);
            IsSuccessful = true;
        }

        public void Run()
        {
            InputModel inputModel = GetInputModelFromUI();
            RunWithInputModel(inputModel);
        }


        private InputModel GetInputModel(string[] args)
        {
            InputModel input = null;
            if (Validator.IsLenghtArgsInvalid(args))
            {
                UI.ShowInstruction();
                throw new ArgumentException("Количество аргументов при старте программы должно было равняться двум");
            }
            else
            {
                if (Validator.IsValidArgs(args))
                {
                    input = new InputModel(args[0], args[1]);
                }
            }

            return input;
        }

        private InputModel GetInputModelFromUI()
        {
            UI.ShowMessage("Нужно задать ширину.");
            int weight = UI.ReadParametr();
            UI.ShowMessage("Нужно задать высоту.");
            int height = UI.ReadParametr();

            return new InputModel(weight,height);
        }
    }
}
