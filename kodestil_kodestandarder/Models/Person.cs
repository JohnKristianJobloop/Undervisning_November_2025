using System;
using System.Security.Cryptography;

namespace kodestil_kodestandarder.Models;

public class Person
{
    public string Name;

    private string _socialSecurityCode;

    public int Age { get; set; }

    public Person(string strName, int intAge)
    {
        Name = strName;

        Age = intAge;

        var arrByte = new byte[32];

        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(arrByte);

        _socialSecurityCode = (string)arrByte.Select(byteRandom => (char)byteRandom);

    }

    /// <summary>
    /// An override of ToString for Person Object.
    /// This prints out the information of the person in a neatly formatted way.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{Name} is {Age} years old, ssc is {_socialSecurityCode}";
    }

    private bool ValidateSocialSecurityCode(string code)
    {
        return _socialSecurityCode == code;
    }

    public bool TryChangeName(string newName)
    {
        throw new NotImplementedException("This method is not yet implemented.");
    }

}
