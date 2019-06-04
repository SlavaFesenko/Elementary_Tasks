using SharedDll;
using System.Collections.Generic;


namespace Task8FibonacciNumbers
{
    public class FibonacciSequence : Sequence
    {
        public FibonacciSequence(int leftNumber, int rightNumber) : base(leftNumber, rightNumber) { }

        public override IEnumerable<int> GetSequenceCollection()
        {
            int current = 0;
            int next = 1;
            while (true)
            {
                if (current >= LeftNumber && current <= RightNumber)
                    yield return current;

                int temp = next;
                next = current + next;
                current = temp;

                if (current > RightNumber)
                    yield break;
            }
        }
    }
}
