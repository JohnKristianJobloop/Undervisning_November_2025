// See https://aka.ms/new-console-template for more information
using System.Text;
using kodestil_kodestandarder.Models;

Console.WriteLine("Hello, World!");

Console.WriteLine("Hello, from Github!");

var person = new Person("John", 33);

var personInfo = person.ToString();

Console.WriteLine(personInfo);

try
{
    person.TryChangeName("John Kristian");
}
catch (NotImplementedException ex)
{
    Console.WriteLine(ex.Message);
}


/* string message = "";
switch (person.Age)
{
    case < 30:
        message = "You're still young!";
        break;
    case < 50:
        message = "You're still young! (i promise!)";
        break;
    case < 80:
        message = "You're still young! I mean it!";
        break;
} */

string message = person.Age switch
{
    < 30 => "You're still young!",
    < 50 => "You're still young, I promise!",
    < 80 => "You're still young, I mean it!",
    _ => throw new ArgumentException("This program only supports people younger than 80.")
};

string numberAsString = "33";

_ = int.TryParse(numberAsString, out var result);


Console.WriteLine(message);

int number = 10;
double fractionalNumber = 1 / 2;

List<string> names = ["John", "Ask", "Jørgen", "Lars Gunnar"];

List<string> emptyList = [];

Dictionary<string, string> nameAndAdress = new()
{
    { "John", "Pappegøyeveien" },
};

// Array av lengde 3, fylt med standardverdier: [0, 0, 0]
var arr1 = new int[3];

// Array av lengde 1, fylt med tallet 3: [3]
int[] arr2 = [3];

var builder = new StringBuilder();
for (int i = 0; i < 100; i++)
{
    builder.Append(names[i % names.Count]);
}
Console.WriteLine(builder.ToString());

var nicelyFormattedText = """
    Hello from a nicely formatted text!


        This keeps all whitespaces and renders it out completely!
""";

names = ["Gunnar", "Kåre", "Ole", "Per", "Pål", "Espen"];

Console.WriteLine(nicelyFormattedText);
