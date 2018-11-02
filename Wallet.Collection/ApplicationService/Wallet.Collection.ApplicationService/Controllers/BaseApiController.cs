using System;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Configuration;
using System.Globalization;
using System.Security.Cryptography;
using Wallet.Collection.Domain.Services;
using Wallet.Collection.ApplicationService.Contract;
using Wallet.Collection.Infrastructure.Contract;

namespace Wallet.Collection.ApplicationService.Controllers
{
    public partial class BaseApiController : ApiController
    {
        private readonly IGateLogger gateLogger;
        private readonly IJsonSerializer jsonSerializer;
        private readonly UserService userDomainService;

        public BaseApiController(UserService userService, IGateLogger gateLogger, IJsonSerializer jsonSerializer)
        {
            this.userDomainService = userService;
            this.gateLogger = gateLogger;
            this.jsonSerializer = jsonSerializer;
        }

        private TResultDTO InternalAuthentication<TResultDTO>(BaseRequestDto request) where TResultDTO : BaseResponseDTO, new()
        {
            TResultDTO result = new TResultDTO();

            var userResponse = this.userDomainService.AuthenticationUser(new Domain.Contract.DomainUserRequestDTO() { UserName = request.UserName, Password = request .Password });
                       
            result.Header.ResponseCode = userResponse.ResponseCode;
            result.Header.Message = userResponse.Message;
            result.Header.Status = userResponse.Status;

            return result;
        }
    }
}