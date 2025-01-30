using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories
{
    public class SolicitudPagoRepository : ISolicitudPagoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public SolicitudPagoRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<SolicitudPagoEntity>> GetListExpiradoAsync()
        {
            var query = await _context.SolicitudesPagos
                .AsNoTracking()
                .Where(sp => sp.Estado == "enviado" || sp.Estado == "reenviado" || sp.Estado == "rechazado")
                .Include(sp => sp.Email)
                .OrderBy(sp => sp.IdSolicitudPago)
                .ToListAsync();

            var result = query
                .AsEnumerable()
                .Where(sp => sp.FechaExpiracion.ToUniversalTime().Ticks < DateTime.UtcNow.ToUniversalTime().Ticks)
                .Select(sp => new SolicitudPagoEntity
                {
                    IdSolicitudPago = sp.IdSolicitudPago,
                    NegocioCod = sp.NegocioCod,
                    CodCliente = sp.CodCliente,
                    NombreCliente = sp.NombreCliente,
                    NombreAgente = sp.NombreAgente,
                    RolAgente = sp.RolAgente,
                    Asunto = sp.Asunto,
                    Telefono = sp.Telefono,
                    Descripcion = sp.Descripcion,
                    Item = sp.Item,
                    LinkPago = sp.LinkPago,
                    NroOrden = sp.NroOrden,
                    Sesion = sp.Sesion,
                    Token = sp.Token,
                    Estado = sp.Estado,
                    Moneda = sp.Moneda,
                    Valor = sp.Valor,
                    FechaRegistro = sp.FechaRegistro,
                    FechaExpiracion = sp.FechaExpiracion,
                    RespuestaTransBank = sp.RespuestaTransBank,
                    Email = new EmailEntity
                    {
                        EmailCliente = sp.Email.EmailCliente,
                        EmailAgente = sp.Email.EmailAgente,
                        EmailAdministrativo = sp.Email.EmailAdministrativo
                    }
                })
                .ToList();

            return result;
        }

        public async Task<List<SolicitudPagoEntity>> GetListAExpirarAsync()
        {
            string delayTimeMinutes = _configuration.GetValue<string>("Delay:TimeMinutes");
            var halfMinutes = Convert.ToInt32(delayTimeMinutes);

            var query = await _context.SolicitudesPagos
                .AsNoTracking()
                .Where(sp => sp.Estado == "enviado" || sp.Estado == "reenviado")
                .Include(sp => sp.Email)
                .OrderBy(sp => sp.IdSolicitudPago)
                .ToListAsync();
            var limitDateTime = DateTime.UtcNow.ToUniversalTime();
            double minutesInf = 1440 - halfMinutes;
            double minutesSup = 1440 + halfMinutes;
            var result = query
                .AsEnumerable()
                .Where(sp =>
                    sp.FechaExpiracion.ToUniversalTime() - limitDateTime >= TimeSpan.FromMinutes(minutesInf) &&
                    sp.FechaExpiracion.ToUniversalTime() - limitDateTime <= TimeSpan.FromMinutes(minutesSup))
                .Select(sp => new SolicitudPagoEntity
                {
                    IdSolicitudPago = sp.IdSolicitudPago,
                    NegocioCod = sp.NegocioCod,
                    CodCliente = sp.CodCliente,
                    NombreCliente = sp.NombreCliente,
                    NombreAgente = sp.NombreAgente,
                    RolAgente = sp.RolAgente,
                    Asunto = sp.Asunto,
                    Telefono = sp.Telefono,
                    Descripcion = sp.Descripcion,
                    Item = sp.Item,
                    LinkPago = sp.LinkPago,
                    NroOrden = sp.NroOrden,
                    Sesion = sp.Sesion,
                    Token = sp.Token,
                    Estado = sp.Estado,
                    Moneda = sp.Moneda,
                    Valor = sp.Valor,
                    FechaRegistro = sp.FechaRegistro,
                    FechaExpiracion = sp.FechaExpiracion,
                    RespuestaTransBank = sp.RespuestaTransBank,
                    Email = new EmailEntity
                    {
                        EmailCliente = sp.Email.EmailCliente,
                        EmailAgente = sp.Email.EmailAgente,
                        EmailAdministrativo = sp.Email.EmailAdministrativo
                    }
                }).ToList();
            return result;
        }

    }
}
