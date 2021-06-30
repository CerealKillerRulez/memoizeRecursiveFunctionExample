using System.Collections.Generic;

namespace memoizeRecursiveFunctionExample
{
    public class FibonacciUtility
    {
        private static Dictionary<ulong, ulong> cache = new Dictionary<ulong, ulong>();
        private static ulong ans;

        public FibonacciUtility() {

        }

        public ulong FibonacciSum(ulong n)
        {
            if (n <= 0) 
                return 1;

            return n > 2 ? FibonacciSum(n - 1) + FibonacciSum(n - 2) : 1;
        }

        public ulong FibonacciSumMemoized(ulong n)
        {
            if (cache.ContainsKey(n))
                return cache[n];

            if (n <= 0)
                return 1;

            ans = n > 2 ? FibonacciSumMemoized(n - 1) + FibonacciSumMemoized(n - 2) : 1;
            cache[n] = ans;

            return ans;
        }

    }
}
