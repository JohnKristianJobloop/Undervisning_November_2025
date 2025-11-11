using System;

namespace Solid_Principles;

public class DependencyInversionPrinciple
{

}

public class SqlOrderRepository
{
    public void Save(Order order) { }
}

//En service bør ikke trenge å lage en Ny (new) utgave av et objekt den er avhengig av (dependent upon) hver gang den trengs. 
//Den skal kunne ta inn en dependency, og bruke den dependencien istedenfor.
/* public class CheckoutService
{
    public void Checkout(Order order)
    {
        var repository = new SqlOrderRepository();
        repository.Save(order); 
    }
} */

public class CheckoutService(SqlOrderRepository repository)
{
    private SqlOrderRepository _repository = repository;

    public void Checkout(Order order)
    {
        _repository.Save(order);
    }
}
