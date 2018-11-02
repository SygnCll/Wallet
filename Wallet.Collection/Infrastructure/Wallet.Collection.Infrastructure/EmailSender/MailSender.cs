using System;
using Wallet.Collection.Infrastructure.Contract;

namespace Wallet.Collection.Infrastructure
{
    public class MailSender : IEmailSender
    {
        public MailSender()
        {
        }

        public void SendEMail(string to, string cc, string bcc, string subject, string body, string attachments)
        {
            throw new NotImplementedException();
        }
    }
}
