using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Collection.Domain.DataModel;

namespace Wallet.Collection.Domain.Repository
{
    public interface IUserRepository
    {
        User GetSingle(long id);

        User GetSingleWithUserCode(string userCode);

        User GetSingleWithEmail(string email);


        User Add(User user);

        void Update(User user);
    }
}
