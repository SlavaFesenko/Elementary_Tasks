using System;

namespace Task7Square
{
    public class InputModel
    {
        public int _maxValue;

        public InputModel(string[] args)
        {
            _maxValue = GetMaxValue(args);
        }

        public static int GetMaxValue(string[] args)
        {
            if (args.Length == 0)
                throw new ArgumentNullException("Please input number!");

            if (Validator.HasParam(args))
            {
                if (int.TryParse(args[0], out int maxValue))
                {
                    if (Validator.IsPozitiveNumber(maxValue))
                        return maxValue;
                    else
                        throw new ArgumentException("Number must be bigger than 0!");
                }
                else
                    throw new FormatException("Unsuccessful format!");
            }
            else
                throw new FormatException("Unsuccessful format!");
        }
    }
}
