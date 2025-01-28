using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ISolicitudPagoRepository
    {
        Task<List<SolicitudPagoEntity>> GetListExpiradoAsync();

        Task<List<SolicitudPagoEntity>> GetListAExpirarAsync();

    }
}
