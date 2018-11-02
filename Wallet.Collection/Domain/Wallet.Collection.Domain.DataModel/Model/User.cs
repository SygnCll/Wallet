using System.Collections.Generic;
using Wallet.Collection.Infrastructure.Enums;

namespace Wallet.Collection.Domain.DataModel
{
    public partial class User : Entity<User, long>
    {
        protected User()
        {
            //Accounts = new HashSet<Account>();
            //Provisions = new HashSet<Provision>();
        }

        public virtual string UserCode { get; protected set; }
        public virtual string Email { get; protected set; }
        public virtual string Password { get; protected set; }
        public virtual StatusType Status { get; protected set; }


        public virtual ICollection<Account> Accounts { get; protected set; }
        public virtual ICollection<Provision> Provisions { get; protected set; }
    }
}
