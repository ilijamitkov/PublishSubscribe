using System;
using Xunit;
using PublishSubscribe;

namespace PublishSubscribe.Tests
{
    public class PublishSubscribeTests
    {
        [Theory]
        [InlineData(1234)]
        [InlineData(5678)]
        [InlineData(78234)]
        public void Input_number_is_the_same_as_the_results_lpfOf(long input)
        {
            LpfPublisher publisher = new LpfPublisher();
            LpfSubscriber subscriberO1 = new LpfSubscriber(publisher);
            long lpfOf = 0;
            subscriberO1.Publisher.OnDataPublished += (object sender, LpfArgument e) =>
            {
                lpfOf = e.Lpf.Insert;
            };

            publisher.Publish(new LargestPrimeFactor
            { 
                Insert = input, 
                Result = MathService.GetLargestPrimeFactor(input)
            });
            Assert.Equal(lpfOf, input);
        }

        [Theory]
        [InlineData(1234, 617)]
        [InlineData(5678, 167)]
        [InlineData(78234, 59)]
        public void Input_prime_number_is_the_same_as_the_results_lpf(long input, long prime)
        {
            LpfPublisher publisher = new LpfPublisher();
            LpfSubscriber subscriberO1 = new LpfSubscriber(publisher);
            long lpf = 0;
            subscriberO1.Publisher.OnDataPublished += (object sender, LpfArgument e) =>
            {
                lpf = e.Lpf.Result;
            };
            publisher.Publish(new LargestPrimeFactor
            {
                Insert = input,
                Result = MathService.GetLargestPrimeFactor(input)
            });

            Assert.Equal(lpf, prime);
        }


        [Theory]
        [InlineData(1234)]
        [InlineData(5678)]
        [InlineData(78234)]
        public void Largest_prime_factor_is_prime(long input)
        {
            LpfPublisher publisher = new LpfPublisher();
            LpfSubscriber subscriberO1 = new LpfSubscriber(publisher);
            long lpf = 0;
            subscriberO1.Publisher.OnDataPublished += (object sender, LpfArgument e) =>
            {
                lpf = e.Lpf.Result;
            };
            publisher.Publish(new LargestPrimeFactor
            {
                Insert = input,
                Result = MathService.GetLargestPrimeFactor(input)
            });

            Assert.True(MathService.IsPrime(lpf));
        }

        [Theory]
        [InlineData(-1234)]
        [InlineData(-5678)]
        [InlineData(-78234)]
        public void Largest_prime_factor_of_negative_number_is_zero(long input)
        {
            LpfPublisher publisher = new LpfPublisher();
            LpfSubscriber subscriberO1 = new LpfSubscriber(publisher);
            long lpf = 0;
            subscriberO1.Publisher.OnDataPublished += (object sender, LpfArgument e) =>
            {
                lpf = e.Lpf.Result;
            };

            publisher.Publish(new LargestPrimeFactor
            {
                Insert = input,
                Result = MathService.GetLargestPrimeFactor(input)
            });

            Assert.Equal(lpf, 0);
        }
    }
}
