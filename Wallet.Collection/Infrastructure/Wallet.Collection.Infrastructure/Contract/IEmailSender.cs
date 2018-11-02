namespace Wallet.Collection.Infrastructure.Contract
{
    public interface IEmailSender
    {
        void SendEMail(string to, string cc, string bcc, string subject, string body, string attachments);
    }
}
