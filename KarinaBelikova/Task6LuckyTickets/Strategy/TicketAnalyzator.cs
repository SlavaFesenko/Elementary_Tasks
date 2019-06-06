namespace Task6LuckyTickets
{
    public  class TicketAnalyzator
    {
        public static int GetCountLuckyTickets(InputModel model)
        {
            int sum = 0;

            for (int i = model.LowLimit; i <= model.UpLimit; i++)
            {
                Ticket ticket = new Ticket(i, model.AlgorithmType);
                if (ticket.IsLucky())               
                    sum++;                               
            }

            return sum;
        }
    }
}
