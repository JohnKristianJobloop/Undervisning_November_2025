using System;

namespace Solid_Principles;


/// <summary>
/// Eksempel på å bryte single responsibility. 
/// 
/// Vi skal ta imot, og behandle ordre mot en database. 
/// </summary>
public class SingleResponsibility
{
    //Kommentert kode bryter single responsibility, fordi objektet har ansvar for flere, uavhengige operasjoner.
    /* public void PlaceOrder(Order order)
    {
        //save to database:
        SaveToDatabase(order);

        File.AppendAllText("orders.log", $"Placed {order.Id}");

        SendEmail(order.Email, "Thank you for ordering!");
    }

    private void SaveToDatabase(Order order) { }

    private void SendEmail(string email, string body) { } */


    //Her fungerer vårt objekt mer som en slags kontrollør, som sender Order videre til andre objekter, som har som eget eneste ansvar, hver sin operasjon. 
    private EmailService MailService { get; set; }
    private DatabaseService DatabaseService { get; set; }

    public void PlaceOrder(Order order)
    {
        MailService.SendEmail(order.Email, "Thanks for ordering");

        DatabaseService.SaveToDatabase(order);
    }

}
public class EmailService
{
    public void SendEmail(string email, string body) { }
}
public class DatabaseService
{
    public void SaveToDatabase(Order order){}
}
public record Order(int Id, string Email, decimal TotalCost);
