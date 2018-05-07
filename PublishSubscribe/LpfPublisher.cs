using System;
namespace PublishSubscribe
{
    public class LargestPrimeFactorPublisher
    {
        public event EventHandler<LargestPrimeFactorArgument> OnDataPublished;

        public void Publish(long number)
        {
            

            OnDataPublished?.Invoke(this, new LargestPrimeFactorArgument(number, GetLargestPrimeFactor(number)));
        }

        private long GetLargestPrimeFactor(long number)
        {
            long largestFact = 0;
            long[] factors = new long[2];

            for (long i = 2; i * i < number; i++)
            {
                if (number % i == 0)
                { // It is a divisor
                    factors[0] = i;
                    factors[1] = number / i;

                    for (int k = 0; k < 2; k++)
                    {
                        bool isPrime = true;
                        for (long j = 2; j * j < factors[k]; j++)
                        {
                            if (factors[k] % j == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                        if (isPrime && factors[k] > largestFact)
                        {
                            largestFact = factors[k];
                        }
                    }
                }
            }

            return largestFact;
        }
    }


}
