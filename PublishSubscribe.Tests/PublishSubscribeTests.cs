using System;
using Xunit;
using PublishSubscribe;

namespace PublishSubscribe.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1234)]
        [InlineData(5678)]
        [InlineData(78234)]
        public void Input_number_is_the_same_as_the_results_lpfOf(long value)
        {
            LpfPublisher publisher = new LpfPublisher();
            LpfSubscriber subscriberO1 = new LpfSubscriber(publisher);
            long lpfOf = 0;
            subscriberO1.Publisher.OnDataPublished += (object sender, LpfArgument e) =>
            {
                lpfOf = e.LpfOf;
            };
            publisher.Publish(value);
            Assert.Equal(lpfOf, value);
        }
    }
}
