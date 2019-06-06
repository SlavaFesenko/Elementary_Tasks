
namespace ChessBoardApp
{
    public class Validator
    {
        public static bool IsCorrect(string[] args)
        {
            bool IsCorrect = false;

            if (Validator.AreTwoArguments(args) && Validator.AreValidNumbers(args))
            {
                IsCorrect = true;
            }
            
            return IsCorrect;
        } 

        private static bool AreTwoArguments(string[] args)
        {
            bool IsCorrect = false;

            if (args.Length == 2)
            {
                IsCorrect = true;
            }

            return IsCorrect;
        }

        private static bool AreValidNumbers(string[] args)
        {
            bool IsCorrect = false;

            if (int.TryParse(args[0], out int width) && int.TryParse(args[1], out int height))
            {
                if(width > 0 && height > 0)
                {
                    IsCorrect = true;
                }
            }

            return IsCorrect;
        }        
    }
}
