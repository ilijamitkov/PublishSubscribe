using System;

namespace PublishSubscribe
{
    public class LpfPublisher
    {
        public event EventHandler<LpfArgument> OnDataPublished;

        public void Publish(LargestPrimeFactor lpf)
        {
            OnDataPublished?.Invoke(this, new LpfArgument(lpf));
        }
    }
}
