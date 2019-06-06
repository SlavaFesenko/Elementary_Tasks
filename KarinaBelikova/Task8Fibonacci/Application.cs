namespace Task8Fibonacci
{
    public class Application
    {
        public static void Run(string[] args)
        {
            int lowLimit = 0;
            int upLimit = 0;

            Validator.Validate(args, out lowLimit, out upLimit);
            Fibonacci fibosequence = new Fibonacci(lowLimit, upLimit);

            UI.PrintFibonacci(lowLimit, upLimit);
        }
    }
}
