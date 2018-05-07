using System;
namespace PublishSubscribe
{
    public class NthPrimeSubscriber
    {
        public NthPrimePublisher Publisher { get; private set; }

        public NthPrimeSubscriber(NthPrimePublisher publisher )
        {
            Publisher = publisher;
        }
    }
}
