using System;
using Wallet.Collection.Infrastructure.Enums;
using Wallet.Collection.Infrastructure.Contract;

namespace Wallet.Collection.Infrastructure
{
    public class DummyEmailSender : IEmailSender
    {
        private readonly ILogger logger;

        public DummyEmailSender(ILogger logger)
        {
            this.logger = logger;
        }

        public void SendEMail(string to, string cc, string bcc, string subject, string body, string attachments)
        {
            string message = string.Format("TO:{0},CC:{1},BCC:{2},Subject:{3},Body:{4},Attachments:{5}", to, cc, bcc, subject, body, attachments);
            logger.Log(new Guid(), message, "", LogType.Debug);
        }
    }
}
