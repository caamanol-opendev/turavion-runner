using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using TuravionWSB;

namespace Infrastructure.Services
{
    public class SendMail : ISendMail
    {
        private readonly ApplicationDbContext _context;
        private readonly TuravionWSBSoapClient envioMailSend;

        public SendMail(ApplicationDbContext context)
        {
            envioMailSend = new TuravionWSB.TuravionWSBSoapClient(TuravionWSB.TuravionWSBSoapClient.EndpointConfiguration.TuravionWSBSoap);
            _context = context;
        }

        public async Task<bool> SendMsgExpirado(SolicitudPagoEntity solicitudPagoEntity)
        {
            var mailEntity = await _context.Mails.FirstOrDefaultAsync(x => x.IdMail == 1);
            var body = mailEntity.MailMsgExpirado;
            var subject = mailEntity.AsuntoMsgExpirado;

            try
            {
                var attachments = Array.Empty<Attachments>();

                var TO = new ArrayOfString
                {
                    solicitudPagoEntity.Email.EmailCliente,
                    solicitudPagoEntity.Email.EmailAgente
                };

                subject = subject.Replace("[Buy Order]", solicitudPagoEntity.NroOrden);

                body = body
                        .Replace("[Client Name]", solicitudPagoEntity.NombreCliente)
                        .Replace("[Services Description]", solicitudPagoEntity.Descripcion);

                TUR_EnviarCorreoRequestBody requestBody = new();
                requestBody.NombreSender = "Turavion";
                requestBody.TO = TO;
                requestBody.CC = new ArrayOfString();
                requestBody.BCC = new ArrayOfString();
                requestBody.Subject = subject;
                requestBody.Body = body;
                requestBody.isHTML = true;
                requestBody.Priority = TuravionWSB.PrioridadCorreo.NORMAL;
                requestBody.Enconding = TuravionWSB.CodificacionCorreo.DEFAULT;
                requestBody.Attachments = attachments;

                var result = await envioMailSend.TUR_EnviarCorreoAsync(new TUR_EnviarCorreoRequest { Body = requestBody });

                if (result != null && result.Body != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> SendMsgAExpirar(SolicitudPagoEntity solicitudPagoEntity, string mainLink)
        {
            var mailEntity = await _context.Mails.FirstOrDefaultAsync(x => x.IdMail == 1);
            var body = mailEntity.MailMsgSolicitud;
            var subject = mailEntity.AsuntoMsgSolicitud;

            try
            {
                var attachments = Array.Empty<Attachments>();

                var TO = new ArrayOfString
                {
                    solicitudPagoEntity.Email.EmailCliente,
                    solicitudPagoEntity.Email.EmailAgente
                };

                subject = subject.Replace("[Buy Order]", solicitudPagoEntity.NroOrden);

                body = body
                        .Replace("[Client Name]", solicitudPagoEntity.NombreCliente)
                        .Replace("[Services Description]", solicitudPagoEntity.Descripcion)
                        .Replace("[Money]", solicitudPagoEntity.Moneda)
                        .Replace("[Value]", solicitudPagoEntity.Valor.ToString())
                        .Replace("[Expiration]", DateOnly.FromDateTime(solicitudPagoEntity.FechaExpiracion).ToString("dd/MMM", System.Globalization.CultureInfo.GetCultureInfo("es-ES")))
                        .Replace("[Payment Link URL]", mainLink);

                TUR_EnviarCorreoRequestBody requestBody = new();
                requestBody.NombreSender = "Turavion";
                requestBody.TO = TO;
                requestBody.CC = new ArrayOfString();
                requestBody.BCC = new ArrayOfString();
                requestBody.Subject = subject;
                requestBody.Body = body;
                requestBody.isHTML = true;
                requestBody.Priority = TuravionWSB.PrioridadCorreo.NORMAL;
                requestBody.Enconding = TuravionWSB.CodificacionCorreo.DEFAULT;
                requestBody.Attachments = attachments;

                var result = await envioMailSend.TUR_EnviarCorreoAsync(new TUR_EnviarCorreoRequest { Body = requestBody });

                if (result != null && result.Body != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
