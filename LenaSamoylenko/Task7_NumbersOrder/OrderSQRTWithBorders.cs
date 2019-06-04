using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CommonThings.AbstractClasses;
using CommonThings.Interfaces;

namespace Task7_NumbersOrder
{
    enum TaskNumber {Task7=7 }

    class OrderSQRTWithBorders : Order
    {
        public OrderSQRTWithBorders()
        {
            SetTaskNumber((int) TaskNumber.Task7);
        }

        public override IEnumerable<int> FindArrayOrder(Range range)
        {
            List<int> collection = new List<int>();

            for (int delta = range.LowerBorder; delta <= range.UpperBorder; delta++)
            {
                collection.Add(delta);
            }

            return collection;
        }

    }
}

