using System;
namespace PublishSubscribe
{
    public class LpfSubscriber
    {
        public LpfPublisher Publisher { get; private set; }

        public LpfSubscriber(LpfPublisher publisher )
        {
            Publisher = publisher;
        }
    }
}
