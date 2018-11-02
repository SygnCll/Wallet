using System;
using System.Runtime.Serialization;

namespace Wallet.Collection.ApplicationService.Contract
{
    [DataContract]
    [Serializable]
    public class UserRequestDTO : BaseRequestDto
    {
        public UserRequestDTO() : base()
        {
        }

        //[DataMember]
        //public UserRequest Body { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string NewPassword { get; set; }

    }

    //[DataContract]
    //[Serializable]
    //public class UserRequest
    //{

    //    [DataMember]
    //    public string Email { get; set; }

    //    [DataMember]
    //    public string Password { get; set; }
    //}
}
