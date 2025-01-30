using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using HostWorker.Models;
using MediatR;
using System.Net;

namespace Application.UseCases.MailOperation.Commands.SendMailExpirado;

public class SendMailExpiradoCommand : IRequest<Response<SendMailExpiradoResponse>>
{
}

public class SendMailExpiradoCommandHandler(
    ISolicitudPagoRepository solicitudPagoRepository,
    IQuerySqlDB<SolicitudPagoEntity> solicitudPagoQuery,
    ICommandSqlDB<SolicitudPagoEntity> solicitudPagoCommand,
    ISendMail sendMail) :
    IRequestHandler<SendMailExpiradoCommand, Response<SendMailExpiradoResponse>>
{
    public async Task<Response<SendMailExpiradoResponse>> Handle(SendMailExpiradoCommand request, CancellationToken cancellationToken)
    {
        var solicitudPagoEntities = await solicitudPagoRepository.GetListExpiradoAsync();

        if (solicitudPagoEntities.Count > 0)
        {
            foreach (var solicitudPagoEntity in solicitudPagoEntities)
            {
                if (solicitudPagoEntity.IdSolicitudPago == 42)
                {
                    var solicitudPago = await solicitudPagoQuery.FirstOrDefaultIncludeAsync(nameof(SolicitudPagoEntity.Email), x => x.IdSolicitudPago == solicitudPagoEntity.IdSolicitudPago, true);
                    solicitudPago.Estado = "expirado";
                    await solicitudPagoCommand.UpdateAsync(solicitudPago);
                    Console.WriteLine("..........Pago actualizado.............");
                    await sendMail.SendMsgExpirado(solicitudPagoEntity);
                    Console.WriteLine("..........Pago enviado.............");
                }

            }

            return new Response<SendMailExpiradoResponse>
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new SendMailExpiradoResponse
                {
                    Result = true
                }
            };

        }

        return new Response<SendMailExpiradoResponse>
        {
            StatusCode = HttpStatusCode.NotFound,
            Content = new SendMailExpiradoResponse
            {
                Result = false
            }
        };

    }
}
