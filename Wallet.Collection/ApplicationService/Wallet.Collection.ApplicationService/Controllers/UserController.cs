using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wallet.Collection.ApplicationService.Contract; 
using Wallet.Collection.Domain.Services;
using Wallet.Collection.Infrastructure.Contract;

namespace Wallet.Collection.ApplicationService.Controllers
{
    [ValidateAntiForgeryToken]
    public class UserController : BaseApiController
    {
        private readonly UserService userDomainService;
        private readonly IGateLogger gateLogger;
        private readonly IJsonSerializer jsonSerializer;
        public UserController(UserService userService, IGateLogger gateLogger, IJsonSerializer jsonSerializer)
            : base(userService, gateLogger, jsonSerializer)
        {
            this.userDomainService = userService;
            this.gateLogger = gateLogger;
            this.jsonSerializer = jsonSerializer;
        }

        [HttpGet]
        public string CheckService()
        {
            return "Service is activate";
        }

        [HttpGet]
        public bool CheckUser(string Email)
        {
            var result = userDomainService.GetUser(Email);

            if (result != null)
                return true;

            return false;
        }
               
        [HttpPost]
        [ValidateAntiForgeryToken]
        public UserResponseDTO CreateUser(UserRequestDTO request)
        {
            var result = new UserResponseDTO();
            var response = this.userDomainService.CreateUser(new Domain.Contract.DomainUserRequestDTO() { Email=request.Email, NewPassword=request.NewPassword, LanguageCode=request.LanguageCode });
            result.Header = new ResponseHeader()
            {
                ResponseCode = response.ResponseCode,
                Message = response.Message,
                Status = response.Status
            };             

            return result;
        }
    }
}
