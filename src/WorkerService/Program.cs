using Application.Extensions;
using Infrastructure.Extensions;
using WorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
