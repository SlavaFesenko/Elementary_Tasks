namespace Task4FileParser
{
    public class InputModel
    {
        public string Path { get; set; }
        public string SearchingString { get; set; }
        public string ReplacementString { get; set; }
        public WorkMode WorkMode { get; set; }

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
