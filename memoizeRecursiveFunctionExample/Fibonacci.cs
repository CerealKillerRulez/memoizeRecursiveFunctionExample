using System.Collections.Generic;

namespace memoizeRecursiveFunctionExample
{
    public class Fibonacci
    {
        private static Dictionary<ulong, ulong> cache = new Dictionary<ulong, ulong>();
        private static ulong answer;
        public ulong RecursionCalls { get; internal set; }


        /// <summary> Clear answers cache </summary>
        public void CleanCache() => cache = new Dictionary<ulong, ulong>();


        /// <summary> Reset Recursions log </summary>
        public void ResetCallsNumber() => RecursionCalls = 0;


        /// <summary> Get the Nth number in Fibonacci Serie (Iterative version)</summary>
        /// <param name="n">the position in the Fibonacci Serie</param>
        /// <returns>The Nth number of Fibonacci in the serie</returns>
        public ulong GetIterative(ulong position) {
            ulong result = 0;
            ulong previous = 1;
            ulong temp;

            for (ulong i = 0; i < position; i++) {
                temp = result;
                result = previous;
                previous = temp + previous;
            }

            return result;
        }


        /// <summary> Get the Nth number in Fibonacci Serie (Recursive version)</summary>
        /// <param name="n">the position in the Fibonacci Serie</param>
        /// <returns>The Nth number of Fibonacci in the serie</returns>
        public ulong GetRecursive(ulong position) {
            RecursionCalls += 1;
            return position >= 2 ? GetRecursive(position - 1) + GetRecursive(position - 2) : position;
        }


        /// <summary> Get the Nth number in Fibonacci Serie (Recursive Memoized version)</summary>
        /// <param name="n">the position in the Fibonacci Serie</param>
        /// <returns>The Nth number of Fibonacci in the serie</returns>
        public ulong GetRecursiveMemoized(ulong position) {
            RecursionCalls += 1;

            if (cache.ContainsKey(position))
                return cache[position];

            answer = position >= 2 ? GetRecursiveMemoized(position - 1) + GetRecursiveMemoized(position - 2) : position;
            cache.Add(position, answer);

            return answer;
        }
    }
}
