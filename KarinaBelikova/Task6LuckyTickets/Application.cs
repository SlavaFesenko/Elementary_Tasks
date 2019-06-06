namespace Task6LuckyTickets
{
    public class Application
    {
        public static void Run(InputModel model)
        {
            int sum = TicketAnalyzator.GetCountLuckyTickets(model);

            UI.ShowCountOfLuckyTickets(sum, model);
        }    
    }
}
