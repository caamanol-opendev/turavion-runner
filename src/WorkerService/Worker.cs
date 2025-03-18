using Application.UseCases.MailOperation.Commands.SendMailAExpirar;
using Application.UseCases.MailOperation.Commands.SendMailExpirado;
using HostWorker.Models;
using MediatR;

namespace WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IConfiguration _configuration;

    public Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory, IConfiguration configuration)
    {
        _logger = logger;
        _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        string delayTimeString = _configuration.GetValue<string>("Delay:TimeMinutes");
        int delayTime = Convert.ToInt32(delayTimeString);

        using (var scope = _scopeFactory.CreateScope())
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var scopedService = scope.ServiceProvider.GetRequiredService<IScopedService>();
                await scopedService.SendMailExpirado();
                await Task.Delay(1000, stoppingToken);
                await scopedService.SendMailAExpirar();
                await Task.Delay(TimeSpan.FromMinutes(delayTime), stoppingToken);
            }

        }

    }
}

public interface IScopedService
{
    Task<bool> SendMailExpirado();

    Task<bool> SendMailAExpirar();
}

public class ScopedService : BaseApiController, IScopedService
{
    private readonly ILogger<ScopedService> _logger;
    private readonly ISender _mediator;

    public ScopedService(ILogger<ScopedService> logger, ISender mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<bool> SendMailExpirado()
    {
        var result = await _mediator.Send(new SendMailExpiradoCommand() { });
        return result.Content.Result;
    }

    public async Task<bool> SendMailAExpirar()
    {
        var result = await _mediator.Send(new SendMailAExpirarCommand() { });
        return result.Content.Result;
    }
}