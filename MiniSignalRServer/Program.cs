using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

var app = builder.Build();
app.MapHub<MyHub>("/horario");

app.MapGet("/", () => "A rota do signalR é /horario");

app.Run();

public class MyHub : Hub
{
    public async IAsyncEnumerable<DateTime> Horario(CancellationToken cancellationToken)
    {
        while (true)
        {
            yield return DateTime.Now;
            await Task.Delay(1000, cancellationToken);
        }
    }
}