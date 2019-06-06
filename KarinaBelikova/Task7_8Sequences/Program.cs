using System;
namespace Task7_8Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                try
                {
                    Console.Write("Enter number of task (7 or 8): ");
                    Task task = (Task)Convert.ToInt32(Console.ReadLine());

                    switch (task)
                    {
                        case Task.SquareSequance:
                            Console.Write("Enter number: ");
                            int maxNumber = int.Parse(Console.ReadLine());

                            if (Validator.IsPozitiveNumber(maxNumber))
                                SequenceUI.PrintSquares(maxNumber);
                            break;
                        case Task.FiboSequence:
                            Console.Write("Low limit: ");
                            int lowLimit = int.Parse(Console.ReadLine());

                            Console.Write("Up limit: ");
                            int upLimit = int.Parse(Console.ReadLine());

                            if (Validator.IsCorrectRange(lowLimit, upLimit))
                                SequenceUI.PrintFibonacci(lowLimit, upLimit);
                            break;
                        default:
                            SequenceUI.Incorrect();
                            break;
                    }
                }
                catch (FormatException)
                {
                    SequenceUI.Incorrect();
                }
            }

            if (args.Length == 2 && Validator.IsCorrectArgs7Task(args, out int[] paramsTask7))
                SequenceUI.PrintSquares(paramsTask7[1]);

            else if (args.Length == 3 && Validator.IsCorrectArgs8Task(args, out int[] paramsTask8))
                SequenceUI.PrintFibonacci(paramsTask8[1], paramsTask8[2]);

            else
                SequenceUI.ShowInstructionsParams();                        

            Console.ReadKey();
        }
    }
}
