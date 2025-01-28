namespace Domain.Entities
{
    public partial class LogEntity
    {
        public int IdLog { get; set; }

        public int? IdSolicitudPago { get; set; }

        public DateTime FechaRegistroSolicitud { get; set; }

        public string EmailCliente { get; set; }

        public string EmailAgente { get; set; }

        public string RolAgente { get; set; }

        public string NroOrden { get; set; }

        public string Estado { get; set; }

        public string Accion { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}
