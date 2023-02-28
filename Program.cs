Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/pascal", (PascalCaseRequest request) =>
{
    Log.Information("Received PascalCase request: {Request}", request);
});

app.MapPost("/camel", (CamelCaseRequest request) =>
{
    Log.Information("Received camelCase Request {Request}", request);
});

app.Run();