using System;
using System.Net;
using System.Text;

namespace WebServerExamples.Moldes;

public class SimpleHttpServer : IDisposable
{
    private readonly HttpListener _listener = new();

    public SimpleHttpServer() => ListenAsync();
    private async void ListenAsync()
    {
        _listener.Prefixes.Add("http://localhost:3001/");

        _listener.Start();

        var context = await _listener.GetContextAsync();

        Console.WriteLine(context.Request.HttpMethod);

        Console.WriteLine(context.Request.RawUrl);

        string responseMessage;

        switch (context.Request.HttpMethod)
        {
            case "GET":
                responseMessage = $"You asked for the following resource {context.Request.RawUrl}.";
                break;
            case "DELETE":
                responseMessage = $"You asked to delete the following resource {context.Request.RawUrl}.";
                break;
            default:
                responseMessage = $"Unsupported Method";
                break;
        }

        context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(responseMessage);

        context.Response.StatusCode = (int)HttpStatusCode.OK;

        using var outputStream = context.Response.OutputStream;

        using var streamWrite = new StreamWriter(outputStream);

        await streamWrite.WriteAsync(responseMessage);
    }

    public void Dispose() => _listener.Close();
}
