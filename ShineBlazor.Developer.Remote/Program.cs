using ShineBlazor.Developer.Tools;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddMcpServer()
    .WithHttpTransport(options =>
    {
        options.Stateless = true;
    })
    .WithTools<ShineBlazorTools>()
    .WithResources<ShineBlazorResources>();

var app = builder.Build();
app.MapMcp();
app.UseHttpsRedirection();

app.Run();
