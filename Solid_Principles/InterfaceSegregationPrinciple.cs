using System;

namespace Solid_Principles;

public class InterfaceSegregationPrinciple
{
    public InterfaceSegregationPrinciple()
    {
        IPrintable printer = new SimpleLaserPrinter();

        printer.Print("Hello");
    }
}

/// <summary>
/// Interface Segregation Principle handler om å passe på at interfacene ikke dekke for mye funksjonalitet. 
/// </summary>
public interface IPrinter
{
    void Print(string text);

    string Scan();

    void Fax(int faxNumber);
}

/// <summary>
/// Denne laser printeren, ville implementere en interface, men har kun mulighet å printe ut, ergo de to andre metodene må covres av en exception throw. 
/// Det vil skape forvirringer for andre utviklere som bruker printeren, siden det ser ut som de virker. 
/// 
/// Nedenfor implemtererer vi classen lettere ved å bryte ned interfacen ovenfor til mindre interfaces. 
/// </summary>
/* public class SimpleLaserPrinter : IPrinter
{
    public void Fax(int faxNumber)
    {
        throw new NotSupportedException();
    }

    public void Print(string text)
    {
        Console.WriteLine(text);
    }

    public string Scan()
    {
        throw new NotSupportedException();
    }
}
 */

public class SimpleLaserPrinter : IPrintable
{
    public void Print(string Text)
    {
        Console.WriteLine(Text);
    }
}

public interface IPrintable
{
    void Print(string Text);
}

public interface IScannable
{
    string Scan();
}

public interface IFaxable
{
    public void Fax(int recieverNumber);
}