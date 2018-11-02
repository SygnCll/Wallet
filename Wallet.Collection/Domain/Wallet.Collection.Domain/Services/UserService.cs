using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Wallet.Collection.Domain.DataModel;
using Wallet.Collection.Domain.Repository;
using Wallet.Collection.Infrastructure.Enums;
using Wallet.Collection.Infrastructure.Contract;
using Wallet.Collection.Domain.Contract;
using Wallet.Collection.Domain.Resource;

namespace Wallet.Collection.Domain.Services
{
    public class UserService : IDomainService
    {
        private readonly IUserRepository userRepository;
        private readonly IEmailSender emailSender;


        public UserService(IUserRepository userRepository, IEmailSender emailSender)
        {
            this.userRepository = userRepository;
            this.emailSender = emailSender;
        }

        public DomainUserResponseDTO AuthenticationUser(DomainUserRequestDTO requestDto)
        {
            DomainUserResponseDTO response = new DomainUserResponseDTO()
            {
                ResponseCode = ServiceResponseCode.USR0006.ToString()
            };

            User user = this.userRepository.GetSingleWithEmail(requestDto.UserName);

            if (user == null)
            {
                response.ResponseCode = ServiceResponseCode.USR0006.ToString();
            }
            else
            {
                if (string.IsNullOrEmpty(user.Password))
                {
                    response.ResponseCode = ServiceResponseCode.USR0006.ToString();
                }
                else if (requestDto.Password != user.Password)
                {
                    response.ResponseCode = ServiceResponseCode.USR0006.ToString();
                }
                else if (user.Status == StatusType.NotAvailable)
                {
                    response.ResponseCode = ServiceResponseCode.USR0009.ToString();
                }
                else
                {
                    response.ResponseCode = ServiceResponseCode.RM0000.ToString();
                    response.UserId = user.Id;
                }
            }

            return response;
        }

        public DomainUserResponseDTO CreateUser(DomainUserRequestDTO requestDto)
        {          
            User user = this.userRepository.GetSingleWithEmail(requestDto.Email);

            if (user != null)
                throw new Exception("User already exists.");

            user = new User(requestDto.Email, requestDto.NewPassword);
            user = this.userRepository.Add(user);

            DomainUserResponseDTO response = new DomainUserResponseDTO()
            {
                ResponseCode = ServiceResponseCode.RM0000.ToString(),
                Status = 0,
                Message = ResponseMessages.Get(ServiceResponseCode.RM0000.ToString(), requestDto.LanguageCode),
                User = user
            };

            return response;
        }

        public string GetUser(string email)
        {
            User user = this.userRepository.GetSingleWithEmail(email);

            return user.Id.ToString();
        }

        public void PassivateUser(string email)
        {
            User user = this.userRepository.GetSingleWithEmail(email);

            if (user.Status == StatusType.NotAvailable)
                throw new Exception(ResponseMessages.Get(ServiceResponseCode.RM0000.ToString(), ""));

            user.Passivate();
            this.userRepository.Update(user);
        }


    }
}
