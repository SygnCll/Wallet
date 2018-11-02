using System;
using System.Runtime.Serialization;

namespace Wallet.Collection.ApplicationService.Contract
{
    [DataContract]
    [Serializable]
    public class CreateUserRequestDTO : UserRequestDTO
    {
        public CreateUserRequestDTO()
        {
        }

    }
}
