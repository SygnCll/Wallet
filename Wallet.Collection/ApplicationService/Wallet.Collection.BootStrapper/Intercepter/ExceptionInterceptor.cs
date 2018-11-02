using System;
using System.Data.Common;
using Castle.DynamicProxy;

namespace Wallet.Collection.BootStrapper.Intercepter
{
    using Wallet.Collection.Infrastructure.Enums;
    using Wallet.Collection.Infrastructure.Contract;
    using Wallet.Collection.ApplicationService.Contract;
    using Wallet.Collection.Domain.Resource;
    using System.Configuration;

    public class ExceptionInterceptor : IInterceptor
    {
        private readonly ILogger logger;

        public ExceptionInterceptor(ILogger logger)
        {
            this.logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (DbException ex)
            {
                Log(invocation, ex, LogType.Error);
                invocation.ReturnValue = GetReturnDto(invocation, ServiceResponseCode.RM0002.ToString(), ex.Message);
            }
            catch (AggregateException ex)
            {
                Log(invocation, ex, LogType.Error);
                invocation.ReturnValue = GetReturnDto(invocation, ServiceResponseCode.RM0001.ToString(), ex.Message);
            }
            catch (ArgumentException ex)
            {
                Log(invocation, ex, LogType.Error);
                invocation.ReturnValue = GetReturnDto(invocation, ServiceResponseCode.RM0002.ToString(), ex.Message);
            }
            catch (Exception ex)
            {
                Log(invocation, ex, LogType.Error);
                invocation.ReturnValue = GetReturnDto(invocation, ServiceResponseCode.RM0002.ToString(), ex.Message);
            }
        }

        private object GetReturnDto(IInvocation invocation, string errorCode, string responseMessage)
        {
            if (invocation.Method.ReturnType == typeof(void))
                return null;

            var returnValue = Activator.CreateInstance(invocation.Method.ReturnType);

            BaseResponseDTO dto = returnValue as BaseResponseDTO;

            if (dto != null)
            {
                dto.Header.ResponseCode = errorCode;
                dto.Header.Message = ResponseMessages.Get(errorCode, this.GetLanguageCode(invocation));
            }

            return returnValue;
        }

        private void Log(IInvocation invocation, Exception exception, LogType logType)
        {
            var requestDTOBase = GetRequestDtoBase(invocation);
            BaseResponseDTO baseResponseDto = invocation.ReturnValue as BaseResponseDTO;
             
            logger.Log(requestDTOBase.TrackId, 
                       $" ResponseCode:{baseResponseDto.Header.ResponseCode}, Method: {invocation.Method.Name}, Message: {exception}",
                       "",
                       logType);
        }

        private string GetLanguageCode(IInvocation invocation)
        {
            if (invocation.Arguments.Length > 0)
            {
                BaseRequestDto dto = GetRequestDtoBase(invocation);

                if (dto != null)
                {
                    return dto.LanguageCode;
                }
            }

            return ConfigurationManager.AppSettings["DefaultLanguageCode"] ?? "tr-TR";
        }

        private BaseRequestDto GetRequestDtoBase(IInvocation invocation)
        {
            return invocation.Arguments.Length > 0 && invocation.Arguments[0] is BaseRequestDto 
                   ? invocation.Arguments[0] as BaseRequestDto
                   : null;
        }
    }
}