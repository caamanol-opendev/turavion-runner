namespace Domain.Entities;

public partial class SolicitudPagoEntity
{
    public int IdSolicitudPago { get; set; }

    public int EmailId { get; set; }

    public string NegocioCod { get; set; }

    public string CodCliente { get; set; }

    public string NombreCliente { get; set; }

    public string NombreAgente { get; set; }

    public string RolAgente { get; set; }

    public string Asunto { get; set; }

    public string Telefono { get; set; }

    public string Descripcion { get; set; }

    public string Item { get; set; }

    public string LinkPago { get; set; }

    public string NroOrden { get; set; }

    public string Sesion { get; set; }

    public string Token { get; set; }

    public string Estado { get; set; }

    public string Moneda { get; set; }

    public decimal Valor { get; set; }

    public DateTime FechaRegistro { get; set; }

    public DateTime FechaExpiracion { get; set; }

    public string RespuestaTransBank { get; set; }

    public virtual EmailEntity Email { get; set; } = null!;

}
