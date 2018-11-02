using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Collection.Infrastructure.Enums;

namespace Wallet.Collection.Domain.DataModel
{
    public partial class User
    {
        public User(string email, string password)
        {
            this.UserCode = GenerateUserCode(email);
            this.Email = email;
            this.Password = password;
            this.CreatedOn = DateTime.Now;
            this.Status = StatusType.Available;
            this.Accounts = new List<Account>();
            this.Provisions = new List<Provision>();

        }

        public virtual void Activate()
        {
            this.Status = StatusType.Available;
        }

        public virtual void Delete()
        {
            this.Status = StatusType.Deleted;
        }

        public virtual void Passivate()
        {
            this.Status = StatusType.NotAvailable;
        }

        private string GenerateUserCode(string email)
        {
            return email.Split('@')[0];
        }
    }
}
