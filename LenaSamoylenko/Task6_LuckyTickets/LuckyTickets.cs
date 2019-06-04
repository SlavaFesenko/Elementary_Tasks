using System.Collections.Generic;

namespace Task6_LuckyTickets
{
    public interface LuckyTickets
    {
        long LowerBorder { get; }
        long UpperBorder { get; }

        int this[long index] { get; }

        IEnumerable<long> GetCollectionOfTickets();
        int CountLuckyTickets();
    }
}
