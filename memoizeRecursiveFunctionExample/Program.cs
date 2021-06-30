using System;

namespace memoizeRecursiveFunctionExample
{
    class Program
    {
        private static readonly FibonacciUtility utility = new FibonacciUtility();

        static void Main(string[] args)
        {
            ulong max = 5000;

            ReportExecution(() => {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Fibonacci memoizzata = {utility.FibonacciSumMemoized(max):N0}");
            });

            ReportExecution(() => {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Fibonacci = {utility.FibonacciSum(max):N0}");
            });

            Console.ReadKey();
        }

        private static void ReportExecution(Action action)
        {
            var startDate = DateTime.Now;

            action();

            Console.WriteLine($"Elaborato in {DateTime.Now.Subtract(startDate).TotalSeconds:N2} secondi.");
            Console.WriteLine();
        }
    }
}
