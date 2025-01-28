using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SolicitudPagoRepository : ISolicitudPagoRepository
    {
        private readonly ApplicationDbContext _context;

        public SolicitudPagoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SolicitudPagoEntity>> GetListExpiradoAsync()
        {
            return [];
            //var query = await _context.SolicitudesPagos
            //    .AsNoTracking()
            //    .Where(sp =>
            //        (sp.Estado == "enviado" || sp.Estado == "reenviado") && 
            //        (sp.FechaExpiracion < DateTime.UtcNow))
            //    .OrderBy(sp => sp.IdSolicitudPago)
            //    .Select(sp => new SolicitudPagoEntity
            //    {
            //        IdSolicitudPago = sp.IdSolicitudPago,
            //        NegocioCod = sp.NegocioCod,
            //        CodCliente = sp.CodCliente,
            //        NombreCliente = sp.NombreCliente,
            //        NombreAgente = sp.NombreAgente,
            //        RolAgente = sp.RolAgente,
            //        Asunto = sp.Asunto,
            //        Telefono = sp.Telefono,
            //        Descripcion = sp.Descripcion,
            //        Item = sp.Item,
            //        LinkPago = sp.LinkPago,
            //        NroOrden = sp.NroOrden,
            //        Sesion = sp.Sesion,
            //        Token = sp.Token,
            //        Estado = sp.Estado,
            //        Moneda = sp.Moneda,
            //        Valor = sp.Valor,
            //        FechaRegistro = sp.FechaRegistro,
            //        FechaExpiracion = sp.FechaExpiracion,
            //        RespuestaTransBank = sp.RespuestaTransBank,
            //        Email = new EmailEntity
            //        {
            //            EmailCliente = sp.Email.EmailCliente,
            //            EmailAgente = sp.Email.EmailAgente,
            //            EmailAdministrativo = sp.Email.EmailAdministrativo
            //        }
            //    }).ToListAsync();
            //return query;
        }

        public async Task<List<SolicitudPagoEntity>> GetListAExpirarAsync()
        {
            return [];
            //var query = await _context.SolicitudesPagos
            //    .AsNoTracking()
            //    .Where(sp =>
            //        (sp.Estado == "enviado" || sp.Estado == "reenviado") && (sp.FechaExpiracion - DateTime.UtcNow).TotalMinutes > 1438 && (sp.FechaExpiracion - DateTime.UtcNow).TotalMinutes < 1443)
            //    .OrderBy(sp => sp.IdSolicitudPago)
            //    .Select(sp => new SolicitudPagoEntity
            //    {
            //        IdSolicitudPago = sp.IdSolicitudPago,
            //        NegocioCod = sp.NegocioCod,
            //        CodCliente = sp.CodCliente,
            //        NombreCliente = sp.NombreCliente,
            //        NombreAgente = sp.NombreAgente,
            //        RolAgente = sp.RolAgente,
            //        Asunto = sp.Asunto,
            //        Telefono = sp.Telefono,
            //        Descripcion = sp.Descripcion,
            //        Item = sp.Item,
            //        LinkPago = sp.LinkPago,
            //        NroOrden = sp.NroOrden,
            //        Sesion = sp.Sesion,
            //        Token = sp.Token,
            //        Estado = sp.Estado,
            //        Moneda = sp.Moneda,
            //        Valor = sp.Valor,
            //        FechaRegistro = sp.FechaRegistro,
            //        FechaExpiracion = sp.FechaExpiracion,
            //        RespuestaTransBank = sp.RespuestaTransBank,
            //        Email = new EmailEntity
            //        {
            //            EmailCliente = sp.Email.EmailCliente,
            //            EmailAgente = sp.Email.EmailAgente,
            //            EmailAdministrativo = sp.Email.EmailAdministrativo
            //        }
            //    }).ToListAsync();
            //return query;
        }

    }
}
