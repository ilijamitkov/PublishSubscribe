using System;

namespace PublishSubscribe
{
    public class LpfArgument : EventArgs
    {
        public LargestPrimeFactor Lpf { get; private set; }

        public LpfArgument(LargestPrimeFactor lpf)
        {
            Lpf = lpf;
        }
    }
}
