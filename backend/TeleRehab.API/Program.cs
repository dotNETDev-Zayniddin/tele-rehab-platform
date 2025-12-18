var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/health", () =>
{
    return Results.Ok(new
    {
        status = "OK",
        service = "TeleRehab API"
    });
});

app.Run();
