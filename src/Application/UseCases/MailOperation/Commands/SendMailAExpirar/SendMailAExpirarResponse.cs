using HostWorker.Models;

namespace Application.UseCases.MailOperation.Commands.SendMailAExpirar
{
    public class SendMailAExpirarResponse : Notify
    {
        public bool Result { get; set; }
    }
}
