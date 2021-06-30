using System;

namespace memoizeRecursiveFunctionExample
{
    class Program
    {
        private static readonly FibonacciUtility utility = new FibonacciUtility();

        static void Main(string[] args)
        {
            ulong fibonacciRow = 45;

            ReportExecution(() => {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Ricorsione memoizzata = {utility.FibonacciSumMemoized(fibonacciRow):N0}");
            });

            ReportExecution(() => {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Ricorsione semplice = {utility.FibonacciSum(fibonacciRow):N0}");
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
