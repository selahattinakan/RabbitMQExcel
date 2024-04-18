using FileCreateWorkerService;
using FileCreateWorkerService.Models;
using FileCreateWorkerService.Services;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddDbContext<AdventureWorks2022Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});

builder.Services.AddSingleton(sp => new ConnectionFactory() { HostName = "localhost", Port = 5672, DispatchConsumersAsync = true });//appsettings'den de alýnabilir
builder.Services.AddSingleton<RabbitMQClientService>();

var host = builder.Build();
host.Run();
