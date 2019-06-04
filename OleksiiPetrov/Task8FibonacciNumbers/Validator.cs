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

                //args.Lenght only = 2, because range take only 2 argumnts
                case 2:
                    args[0] = args[0].Trim(new char[] { ',' });//TODO: к типу данних аргс0
                    if (int.TryParse(args[0], out int startPosition) && int.TryParse(args[1], out int endPosition))
                    {
                        if (startPosition < endPosition)
                        {
                            if ((startPosition >= 0) && (endPosition >= 0))
                                return true;
                            else
                                throw new ArgumentException("Values must be > 0");
                        }
                        else
                            throw new ArgumentException("First values must be less than second value.");
                    }
                    else
                        throw new ArgumentException("Values is not integer");

                default:
                    throw new ArgumentException("There should be 2 variables");
            }

        }
    }
}