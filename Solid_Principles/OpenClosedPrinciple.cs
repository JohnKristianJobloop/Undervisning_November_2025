using System;

namespace Solid_Principles;

/// <summary>
/// Eksempel på å bryte open/closed principle.
/// 
/// Calculate Discount er explisitt linket til (åpnet mot) ekstern Enum customerType.
/// </summary>
public class OpenClosedPrinciple
{
    //Denne metoden bryter med prinsippet, siden den er eksplisitt avhengig av CustomerType enumen.

    /* public decimal CalculateDiscountForCusomerType(CustomerType type, decimal ammount)
    {
        return type switch
        {
            CustomerType.Regular => ammount * 0.95m,
            CustomerType.Vip => ammount * 0.80m,
            CustomerType.SuperVip => ammount * 0.75m,
            _ => throw new NotSupportedException("Unknown Type")
        };
    } */

    //Denne bryter ikke Open/Closed siden den er ikke lengre eksplisitt knyttet til CustomerType
    public decimal CalculateDiscountForCustomer(CustomerData customer, decimal ammount) => customer.Discount * ammount;
}

public enum CustomerType { Regular, Vip, SuperVip, SuperDuperVip }

public record CustomerData(CustomerType Type, decimal Discount);
