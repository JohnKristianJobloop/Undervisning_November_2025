// See https://aka.ms/new-console-template for more information
using StackImplementation_November.Models;
using StackImplementation_November.Services;

Console.WriteLine("Hello, World!");


var integerStack = new KhStack<int>();

integerStack.Push(10);
integerStack.Push(4);
integerStack.Push(32);

var minimum = integerStack.Min();
Console.WriteLine(minimum);

var multipliedStackNumbers = integerStack.Select(number => number * 2);

foreach (var number in multipliedStackNumbers) Console.WriteLine(number);

var found = integerStack.Pop();

Console.WriteLine(found);

Console.WriteLine(found.GetType());

var stringStack = new KhStack<string>();

stringStack.Push("Hallais!");

var foundString = stringStack.Pop();

Console.WriteLine(foundString);

Console.WriteLine(foundString.GetType());

var service = new KhStackService<string>(stringStack);