namespace Domain.Entities
{
    public class EmailEntity
    {
        public int IdEmail { get; set; }

        public string EmailCliente { get; set; }

        public string EmailAgente { get; set; }

        public string EmailAdministrativo { get; set; }

        public virtual ICollection<SolicitudPagoEntity> SolicitudesPagos { get; set; } = [];

    }
}
