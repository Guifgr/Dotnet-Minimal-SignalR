using Microsoft.AspNetCore.SignalR.Client;

var url = "https://localhost:7214/horario";

await using var connection = new HubConnectionBuilder().WithUrl(url).Build();

await connection.StartAsync();

await foreach (var date in connection.StreamAsync<DateTime>("Horario"))
{
    Console.WriteLine(date);
}

Console.WriteLine("Hello, World!");