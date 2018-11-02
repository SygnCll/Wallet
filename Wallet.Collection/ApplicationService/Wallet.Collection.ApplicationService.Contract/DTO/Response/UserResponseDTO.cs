using System;
using System.Runtime.Serialization;

namespace Wallet.Collection.ApplicationService.Contract
{
    [DataContract]
    [Serializable]
    public class UserResponseDTO : BaseResponseDTO
    {
        public UserResponseDTO() : base()
        {
        }

        [DataMember]
        public UserResponseBody Body { get; set; }
    }


    [DataContract]
    [Serializable]
    public class UserResponseBody
    {

    }
}
