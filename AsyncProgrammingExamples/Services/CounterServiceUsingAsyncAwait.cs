using System;
using System.Diagnostics.Metrics;
using AsyncProgrammingExamples.Models;

namespace AsyncProgrammingExamples.Services;

public static class CounterServiceUsingAsyncAwait
{
    public static async Task CountTwoCounterWithAsyncAwait()
    {
        Console.WriteLine("Starting Async Await...");

        var counter = new Counter("Async Counter 1", 8, 100);
        var task1 = CountCounterAsync(counter);


        var counter2 = new Counter("Async Counter 2", 5, 300);
        var task2 = CountCounterAsync(counter2);

        await Task.WhenAll(task1, task2);
        Console.WriteLine("All tasks completed");

    }

    private static async Task CountCounterAsync(Counter counter)
    {
        Console.WriteLine($"{counter.Name} starts...");

        for (var i = 1; i <= counter.Count; i++)
        {
            await Task.Delay(counter.DelayInMilliseconds);
            Console.WriteLine($"{counter.Name} has counted {i} / {counter.Count}.");
        }

        Console.WriteLine($"{counter.Name} has finished.");
    }
}
