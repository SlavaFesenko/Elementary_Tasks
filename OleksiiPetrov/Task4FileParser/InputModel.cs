namespace Task4FileParser
{
    public class InputModel
    {
        public string Path { get; private set; }
        public string SearchingString { get; private set; }
        public string ReplacementString { get; private set; }
        public WorkMode WorkMode { get; private set; }

        public InputModel(string[] args)
        {
            if (args.Length == 2)
            {
                Path = args[0];
                SearchingString = args[1];
                WorkMode = WorkMode.Find;
            }
            if (args.Length == 3)
            {
                Path = args[0];
                SearchingString = args[1];
                ReplacementString = args[2];
                WorkMode = WorkMode.Replace;
            }
        }
    }
}
