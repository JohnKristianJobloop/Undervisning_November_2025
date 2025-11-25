using StackImplementation_November.Models.PlayingCard;
using StackImplementation_November.Services.PlayingCard;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging(options => options.AddConsole());
builder.Services.AddSingleton<PlayingCardService<Card>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/Hello", ()=>"Hello, world!");

app.MapGet("/cards/{amount:int}", (int amount) =>
{
    try
    {
        var logger = app.Services.GetService<ILogger<Program>>();
        var service = app.Services.GetService<PlayingCardService<Card>>();
        logger.LogInformation(service.Count.ToString());
        var list = service.Draw(amount).ToList();
        foreach (var card in list) logger.LogInformation(card.Name);
        return Results.Ok(list);
    }
    catch (IndexOutOfRangeException ex)
    {
        return Results.Problem(ex.Message, statusCode: 410);
    }
});

app.MapGet("/cards/reset", (PlayingCardService<Card> playingCardService) =>
{
    playingCardService.ResetDeck();
    return Results.NoContent();
});

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.UseDefaultFiles();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
