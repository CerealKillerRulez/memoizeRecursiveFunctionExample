using System;

namespace memoizeRecursiveFunctionExample
{
    class Program
    {
        private static readonly Fibonacci fibonacci = new Fibonacci();
        private static ulong position = 35; //mid 35, max 93

        static void Main(string[] args)
        {
            DrawStartMessage();

            ReportExecution(() =>
                Console.WriteLine($"Funzione iterativa (posizione {position}) = {fibonacci.GetIterative(position):N0}"),
                ConsoleColor.Red);
            Console.ReadKey();


            ReportExecution(() =>
                Console.WriteLine($"Ricorsione memoizzata (posizione {position}) = {fibonacci.GetRecursiveMemoized(position):N0} (in {fibonacci.RecursionCalls:N0} ricorsioni)"),
                ConsoleColor.Yellow);
            Console.ReadKey();


            ReportExecution(() =>                 
                Console.WriteLine($"Ricorsione memoizzata (posizione {position + 5}) = {fibonacci.GetRecursiveMemoized(position + 5):N0} (in {fibonacci.RecursionCalls:N0} ricorsioni)"),
                ConsoleColor.Yellow);
            Console.ReadKey();


            ReportExecution(() =>
                Console.WriteLine($"Ricorsione semplice (posizione {position}) = {fibonacci.GetRecursive(position):N0} (in {fibonacci.RecursionCalls:N0} ricorsioni)"),
                ConsoleColor.Green);
            Console.ReadKey();
        }


        private static void DrawStartMessage()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Numero della serie di Fibonacci alla posizione {position} (ENTER per calcolare):\n");
            Console.ReadKey();
        }


        private static void ReportExecution(Action action, ConsoleColor color)
        {
            var startDate = DateTime.Now;

            Console.ForegroundColor = color;
            fibonacci.ResetCallsNumber();

            action();

            Console.WriteLine($"Elaborato in {DateTime.Now.Subtract(startDate).TotalSeconds:N2} secondi.");
            Console.WriteLine();
        }
    }
}
