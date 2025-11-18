using WebServerExamples.Moldes;
var client = new HttpClient();


using var server = new SimpleHttpServer();

var response = await client.GetAsync("http://localhost:3001/index.html");

Console.WriteLine(response);

Console.WriteLine(await response.Content.ReadAsStringAsync());

