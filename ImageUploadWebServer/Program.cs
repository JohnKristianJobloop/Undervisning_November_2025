using System.Net;
using ImageUploadWebServer.Models;

HttpListener listener = new();

var indexFilePath = "./wwwroot/index.html";

listener.Prefixes.Add("http://+:3002/");

listener.Start();

var uploadServer = new ImageService();

Console.WriteLine("Started listening on: " + "http://localhost:3002/");

while(true)
{
    var context = await listener.GetContextAsync();

    Console.WriteLine($"Recieved request: {context.Request}");

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    Task.Run(async () =>
    {
        var request = context.Request;
        var response = context.Response;
        response.AddHeader("Access-Control-Allow-Origin", "https://13c58d493d91.ngrok-free.app"); // Allow requests from any origin
        response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS"); // Allow common HTTP methods
        response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Authorization"); // Allow common headers


        switch(request.HttpMethod)
        {

            case "OPTIONS":
                context.Response.StatusCode = 200;
                context.Response.OutputStream.Close();
                break;
            case "GET":
                if (request.RawUrl == "/")
                {
                    var data = await File.ReadAllBytesAsync(indexFilePath);
                    context.Response.StatusCode = 200;
                    context.Response.ContentType = "text/html";
                    await context.Response.OutputStream.WriteAsync(data);

                }
                else if(request.RawUrl == "/wwwroot/Images/all")
                {
                    await uploadServer.FetchAllImageUrls(context);
                }
                else
                {
                    await uploadServer.FetchImage(context);
                }
                break;
            case "POST":
                await uploadServer.RecieveImage(context);
                break;
            default:
                context.Response.StatusCode = 501;
                break;
        }
        response.OutputStream.Close();
    });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

}