using System;

namespace Solid_Principles;

public static class LiskovSubstitutionPrinciple
{
    public static void Run()
    {
        var eagle = new Eagle();
        var penguin = new Penguin();
        MakeBirdsFly(eagle);
        /* MakeBirdsFly(penguin);  *///siden denne her vil throw en exception, bryter det med LSP, som sier at en superklasse av en baseklasse, kan ikke bryte med / gjøre utilgjengelig funksjonalitet fra baseklassen. 
    }
    public static void MakeBirdsFly(BirdWithFlight bird) => bird.Fly();
}



public class Bird
{
    
}
//Vi fikser problemet med å se at Fly burde ikke være i baseklassen, siden ikke alle fugler kan fly!
public class BirdWithFlight : Bird
{
    public virtual void Fly() => Console.WriteLine("Flapping my wings!");
}


public class Eagle : BirdWithFlight
{
    public override void Fly() => Console.WriteLine("Soaring high, looking for prey!");
}

public class Penguin : Bird
{
}