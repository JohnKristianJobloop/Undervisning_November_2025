using System;
using System.Net;
using System.Text.Json;
using ImageUploadWebServer.Interfaces;

namespace ImageUploadWebServer.Models;

public class ImageService : IImageUploadWebServer
{

    private readonly string _imageRootFilePath = "./wwwroot/Images/";

    private Dictionary<string, string> ValidImageMimeTypes = new ()
    {
        ["image/bmp"] = ".bmp",
        ["image/avif"] = ".avif",
        ["image/apng"] = ".apng",
        ["image/png"] = ".png",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/webp"] = ".webp",
        ["image/jpeg"] = ".jpg",
        ["image/gif"] = ".gif"
    };
    public async Task FetchAllImageUrls(HttpListenerContext context)
    {
       var files = Directory.GetFiles(_imageRootFilePath);

       var fileNames = Array.ConvertAll(files, Path.GetFileName);

        /* [
        "filename 1",
        "filename 2",
        ]  */

        var json = JsonSerializer.Serialize(fileNames);

        context.Response.ContentType = "application/json";

        using var outputStream = context.Response.OutputStream;

        using var streamWriter = new StreamWriter(outputStream);

        await streamWriter.WriteAsync(json);
    }

    public async Task FetchImage(HttpListenerContext context)
    {
        var fileName = "." + context.Request.RawUrl;
        Console.WriteLine(context.Request.RawUrl);
        if (!File.Exists(fileName))
        {
            context.Response.StatusCode = 404;
            return;
        }

        var data = await File.ReadAllBytesAsync(fileName);
        var ext = fileName.Split(".")[2];
        var mimeType = ValidImageMimeTypes.Where(pair => pair.Value == $".{ext}").Select(pair => pair.Key).FirstOrDefault();
        if (mimeType is null)
        {
            context.Response.StatusCode = 500;
            return;
        }
        context.Response.ContentType = mimeType;
        await context.Response.OutputStream.WriteAsync(data);
    }

    public Task RecieveImage(HttpListenerContext context)
    {
         return Task.Run(async () =>
        {
            var response = context.Response;
            var request = context.Request;

            if (!request.HasEntityBody)
            {
                response.StatusCode = 400;
                return;
            }
            if (string.IsNullOrWhiteSpace(request.ContentType) || !ValidImageMimeTypes.TryGetValue(request.ContentType, out var fileExtention))
            {
                response.StatusCode = 415;
                return;
            }

            using var ms = new MemoryStream();

            await request.InputStream.CopyToAsync(ms);

            var data = ms.ToArray();

            var filename = $"img_{Guid.NewGuid()}{fileExtention}";

            var filePath = Path.Combine(_imageRootFilePath, filename);

            await File.WriteAllBytesAsync(filePath, data);

            response.StatusCode = 200;
            return;
        });
    }
}
