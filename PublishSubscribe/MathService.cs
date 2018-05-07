using System;
namespace PublishSubscribe
{
    public static class MathService
    {
        public static bool IsPrime(long number) 
        { 
            if (number < 2) 
            { 
                return false; 
            }

            for (var divisor = 2; divisor <= Math.Sqrt(number); divisor++) 
            { 
                if (number % divisor == 0) 
                { 
                    return false; 
                } 
            } 
            return true;  
        }

        public static long GetLargestPrimeFactor(long number)
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
