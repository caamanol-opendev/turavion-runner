namespace Domain.Entities
{
    public partial class MailEntity
    {
        public int IdMail { get; set; }

        public string MailMsgExitoso { get; set; }

        public string AsuntoMsgExitoso { get; set; }

        public string MailMsgRechazado { get; set; }

        public string AsuntoMsgRechazado { get; set; }

        public string MailMsgExpirado { get; set; }

        public string AsuntoMsgExpirado { get; set; }

        public string MailMsgExpira { get; set; }

        public string AsuntoMsgExpira { get; set; }

        public string MailMsgSolicitud { get; set; }

        public string AsuntoMsgSolicitud { get; set; }
    }
}
