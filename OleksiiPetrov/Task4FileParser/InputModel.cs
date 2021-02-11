namespace Task4FileParser
{
    public class InputModel
    {
        public string Source { get; private set; }
        public string SearchingString { get; private set; }
        public string ReplacementString { get; private set; }
        public WorkMode WorkMode { get; private set; }

        public InputModel(string[] args)
        {
            if (args.Length == 2)
            {
                Source = args[0];
                SearchingString = args[1];
                WorkMode = WorkMode.Find;
            }
            if (args.Length == 3)
            {
                Source = args[0];
                SearchingString = args[1];
                ReplacementString = args[2];
                WorkMode = WorkMode.Replace;
            }
        }
    }
}
