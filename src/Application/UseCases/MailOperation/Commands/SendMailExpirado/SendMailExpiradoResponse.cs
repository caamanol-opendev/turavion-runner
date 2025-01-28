using HostWorker.Models;

namespace Application.UseCases.MailOperation.Commands.SendMailExpirado
{
    public class SendMailExpiradoResponse : Notify
    {
        public bool Result { get; set; }
    }
}
