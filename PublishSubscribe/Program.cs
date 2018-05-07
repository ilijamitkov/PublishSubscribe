using System;
using Easy.MessageHub;
namespace PublishSubscribe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Base implementation of the Publish/Subscribe pattern good only for very small projects
            var lpfPublisher = InitWithEventHandler();

            // Example of using open source library which implements the Event Aggregator Pattern
            // https://github.com/NimaAra/Easy.MessageHub
            var hub = InitWithAggregator();

            while (true)
            {
                Console.WriteLine("Insert number to find the largest prime factor of it");
         
                if (long.TryParse(Console.ReadLine().Trim(), out long n))
                {
                    var lpf = new LargestPrimeFactor
                    {
                        Insert = n,
                        Result = MathService.GetLargestPrimeFactor(n)
                    };

                    lpfPublisher.Publish(lpf);
                    hub.Publish(lpf);
                }
                else
                {
                    Console.WriteLine("Please insert a valid number (Signed 64-bit integer)");
                }
            }
        }

        public static LpfPublisher InitWithEventHandler()
        {
            var lpfPublisher = new LpfPublisher();
            LpfSubscriber subscriberO1 = new LpfSubscriber(lpfPublisher);
            LpfSubscriber subscriberO2 = new LpfSubscriber(lpfPublisher);

            subscriberO1.Publisher.OnDataPublished += (object sender, LpfArgument e) =>
            {
                Console.WriteLine($"Subscriber 01: Largest Prime Factor of {e.Lpf.Insert} is {e.Lpf.Result}");
            };
            subscriberO2.Publisher.OnDataPublished += (object sender, LpfArgument e) =>
            {
                Console.WriteLine($"Subscriber 02: Largest Prime Factor of {e.Lpf.Insert} is {e.Lpf.Result}");
            };
            return lpfPublisher;
        }

        public static MessageHub InitWithAggregator()
        {
            var hub = MessageHub.Instance;
            Action<LargestPrimeFactor> subscribero3 = s =>
            {
                Console.WriteLine($"Subscriber 03: Largest Prime Factor of {s.Insert} is {s.Result}");
            };
            Action<LargestPrimeFactor> subscribero4 = s =>
            {
                Console.WriteLine($"Subscriber 04: Largest Prime Factor of {s.Insert} is {s.Result}");
            };

            hub.Subscribe(subscribero3);
            hub.Subscribe(subscribero4);
            return hub;
        }
    }
}
