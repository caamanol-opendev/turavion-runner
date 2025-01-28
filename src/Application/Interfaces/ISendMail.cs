using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISendMail
    {
        Task<bool> SendMsgAExpirar(SolicitudPagoEntity solicitudPagoEntity, string mainLink);

        Task<bool> SendMsgExpirado(SolicitudPagoEntity solicitudPagoEntity);
    }
}
