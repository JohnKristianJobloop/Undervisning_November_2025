using System;
using System.Net;

namespace ImageUploadWebServer.Interfaces;

public interface IImageUploadWebServer
{
    public Task RecieveImage(HttpListenerContext context);

    public Task FetchAllImageUrls(HttpListenerContext context);

    public Task FetchImage(HttpListenerContext context);
}
