
using AsyncProgrammingExamples.Models;

namespace AsyncProgrammingExamples.Services;

public static class CounterServiceUsingThreadClass
{
    public static void CountCountersOnTwoThreads()
    {
        //Vi setter opp, første counter, og første thread.
        var counter = new Counter("Counter 1", 5, 200);
        var thread = new Thread(CountCounterOnThread);

        //Vi setter opp andre counter, og andre thread.
        var counter2 = new Counter("Counter 2", 3, 400);
        var thread2 = new Thread(CountCounterOnThread);

        thread.Start(counter);
        thread2.Start(counter2); 

        thread.Join();
        thread2.Join();

        Console.WriteLine("Both Threads have finished operation!");
    }

    private static void CountCounterOnThread(object? state)
    {
        var counter = (Counter)state!;
        Console.WriteLine($"Thread {counter.Name}: Started...");

        for (var i = 1; i <= counter.Count; i++)
        {
            Thread.Sleep(counter.DelayInMilliseconds);

            Console.WriteLine($"{counter.Name} has counted {i} / {counter.Count}.");
        }
    }


}
