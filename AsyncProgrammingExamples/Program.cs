/* 

Eksempel på en svært simpel form for asynkron programmering. 

var newThread = new Thread(WriteOnNewThread);
newThread.Start();


static void WriteOnNewThread()
{
    for (var i = 0; i < 1000; i++)
    {
        Console.WriteLine($"Did operation{i}");
    }
}

for (var j = 0; j < 1000; j++)
{
    Console.WriteLine($"Did operation {j} on original thread");
} */

using AsyncProgrammingExamples.Services;

CounterServiceUsingThreadClass.CountCountersOnTwoThreads();

var task =  CounterServiceUsingTaskCompletionSource.CountTwoCountersUsingTask();

for (var i = 0; i < 100; i++)
{
    Console.WriteLine(i);
}
await task;

await CounterServiceUsingAsyncAwait.CountTwoCounterWithAsyncAwait();
