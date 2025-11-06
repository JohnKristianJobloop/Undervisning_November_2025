// See https://aka.ms/new-console-template for more information
using StackImplementation_November.Models;
using StackImplementation_November.Services;

Console.WriteLine("Hello, World!");


var integerStack = new KhStack<int>();

var listOfNumbers = new List<int>();

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

stringStack.Push("Mornings!");

stringStack.Push("Hallaien!");

stringStack.Push("God Morgen.");

var bergenskHilsen = stringStack.FirstOrDefault(hilsen => string.Equals(hilsen, "hallaien!", StringComparison.OrdinalIgnoreCase));

var foundString = stringStack.Pop();

Console.WriteLine(foundString);

Console.WriteLine(foundString.GetType());

var service = new KhStackService<string>(stringStack);

var catStack = new KhStack<Cat>();

catStack.Push(new Cat("Zeus", "Norsk Skogskatt", 10));


record Cat(string Name, string Breed, int Age);