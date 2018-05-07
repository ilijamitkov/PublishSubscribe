using System;
using System.Collections.Generic;

namespace PublishSubscribe
{
    public class LargestPrimeFactorArgument : EventArgs
    {
        public long LargestPrimeFactor { get; private set; }
        public long Number { get; private set; }

        public LargestPrimeFactorArgument(long number, long largestPrimeFactor)
        {
            Number = number;
            LargestPrimeFactor = largestPrimeFactor;
        }
    }
}
