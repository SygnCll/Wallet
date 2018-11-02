using System;
using System.Linq;
using System.Collections.Generic;
using Wallet.Collection.Domain.DataModel;
using Wallet.Collection.Infrastructure.Repository;

namespace Wallet.Collection.Domain.Repository
{
    public class UserRepository : BaseEntityRepository<User>, IUserRepository
    {
        public UserRepository(IRepository<User> userRepository) : base(userRepository)
        {

        }

        public User GetSingle(long id)
        {
            throw new NotImplementedException();
        }

        public User GetSingleWithEmail(string email)
        {
            var user = base.Repository.Get(u => u.Email == email);

            return user;
        }

        public User GetSingleWithUserCode(string userCode)
        {
            throw new NotImplementedException();
        }
    }
}
