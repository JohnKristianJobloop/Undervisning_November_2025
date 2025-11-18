
var client = new HttpClient();

var response = await client.GetAsync("https://excalidraw.com/");

Console.WriteLine(response.StatusCode);
var contentLength = response.Content.Headers.ContentLength;
Console.WriteLine(contentLength);
var contentType = response.Content.Headers.ContentType;
Console.WriteLine(contentType);


using var fileStream = File.Create("nrk.html");
await response.Content.CopyToAsync(fileStream);

var response2 = await client.GetAsync("Https://www.nrk.no");