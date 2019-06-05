using System;


namespace Task8FibonacciNumbers
{
    public static class Validator
    {
        public static bool IsValid(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    throw new ArgumentException("Count values must be = 2.");

                //args.Length only = 2, because range take only 2 arguments
                case 2:
                    InputModel input = new InputModel(args);
                    if (input.LeftNumber < input.RightNumber)
                    {
                        if ((input.LeftNumber >= 0) && (input.RightNumber >= 0))
                            return true;
                        else
                            throw new ArgumentException("Values must be > 0");
                    }
                    else
                        throw new ArgumentException("First values must be less than second value.");


                default:
                    throw new ArgumentException("There should be 2 variables");
            }

        }
    }
}