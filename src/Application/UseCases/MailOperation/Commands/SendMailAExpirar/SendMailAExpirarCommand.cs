using Application.Helpers;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using HostWorker.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Application.UseCases.MailOperation.Commands.SendMailAExpirar;

public class SendMailAExpirarCommand : IRequest<Response<SendMailAExpirarResponse>>
{
}

public class SendMailAExpirarCommandHandler(
    ISolicitudPagoRepository solicitudPagoRepository,
    ISendMail sendMail,
    IConfiguration configuration) :
    IRequestHandler<SendMailAExpirarCommand, Response<SendMailAExpirarResponse>>
{
    public async Task<Response<SendMailAExpirarResponse>> Handle(SendMailAExpirarCommand request, CancellationToken cancellationToken)
    {
        var solicitudPagoEntities = await solicitudPagoRepository.GetListAExpirarAsync();

        if (solicitudPagoEntities.Count > 0)
        {
            foreach (var solicitudPagoEntity in solicitudPagoEntities)
            {
                //var mainLink = configuration.GetValue<string>("TransferPagin:Url") + ConvertTo.Base64(solicitudPagoEntity.IdSolicitudPago);
                //await sendMail.SendMsgAExpirar(solicitudPagoEntity, mainLink);
            }

            return new Response<SendMailAExpirarResponse>
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new SendMailAExpirarResponse
                {
                    Result = true
                }
            };

        }

        return new Response<SendMailAExpirarResponse>
        {
            StatusCode = HttpStatusCode.NotFound,
            Content = new SendMailAExpirarResponse
            {
                Result = false
            }
        };

    }
}
