using System;
using System.Diagnostics.Metrics;
using AsyncProgrammingExamples.Models;

namespace AsyncProgrammingExamples.Services;

public class CounterServiceUsingTaskCompletionSource
{
    //tsc
    public static Task CountTwoCountersUsingTask()
    {
        var masterTsc = new TaskCompletionSource();

        var counter = new Counter("Task Counter 1", 6, 250);
        var task1 = CountCounterWithTsc(counter);
        

        var counter2 = new Counter("Task Counter 2", 4, 200);
        var task2 = CountCounterWithTsc(counter2);

        Task.WhenAll(task1, task2).ContinueWith(allTasks =>
        {
            if (allTasks.IsFaulted)
            {
                masterTsc.SetException(allTasks.Exception);
            }
            else
            {
                Console.WriteLine("All tasks completed");
                masterTsc.SetResult();
            }
        });

        return masterTsc.Task;
    }


    private static Task CountCounterWithTsc(Counter counter)
    {
        var tsc = new TaskCompletionSource();

        Task.Run(() =>
        {
            try
            {
                Console.WriteLine($"{counter.Name} starts counting..");

                CountWithTaskAwaiter(counter, tsc);
            }
            catch(Exception ex)
            {
                tsc.SetException(ex);
            }
        });
        
        return tsc.Task;
    }

    private static void CountWithTaskAwaiter(Counter counter, TaskCompletionSource tsc)
    {
        int currentCount = 1;

        void Continuation()
        {
            try
            {
                if (currentCount <= counter.Count)
                {
                    var delayTask = Task.Delay(counter.DelayInMilliseconds);

                    Console.WriteLine($"{counter.Name} has counted {currentCount++} / {counter.Count}.");

                    var awaiter = delayTask.GetAwaiter();

                    awaiter.OnCompleted(() =>
                    {
                       Continuation(); 
                    });
                }
                else
                {
                    Console.WriteLine($"{counter.Name} has completed");
                    tsc.SetResult();
                }
            }
            catch (Exception ex)
            {
                tsc.SetException(ex);
            }
        }

        Continuation();
    }
}
