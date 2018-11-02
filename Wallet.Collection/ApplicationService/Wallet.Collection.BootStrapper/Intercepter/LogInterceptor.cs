using System;
using System.Linq;
using Castle.DynamicProxy;
using Wallet.Collection.Infrastructure.Contract;
using Wallet.Collection.ApplicationService.Contract;
using System.Diagnostics;

namespace Wallet.Collection.BootStrapper.Intercepter
{
    public class LogInterceptor : IInterceptor
    {
        private readonly IGateLogger gateLogger;
        private readonly IJsonSerializer jsonSerializer;

        public LogInterceptor(IGateLogger gateLogger, IJsonSerializer jsonSerializer)
        {
            this.gateLogger = gateLogger;
            this.jsonSerializer = jsonSerializer;
        }

        public void Intercept(IInvocation invocation)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var requestDtoBase = this.GetRequestDTOBase(invocation);
            requestDtoBase.TrackId = requestDtoBase.TrackId == Guid.Empty ? requestDtoBase.TrackId = Guid.NewGuid() : requestDtoBase.TrackId;

            invocation.Proceed();
            stopWatch.Stop();

            gateLogger.LogForIncoming(requestDtoBase.TrackId,
                                      null,
                                      invocation.Method.Name,
                                      $"{this.GetRequestMessage(invocation)}",
                                      $"{this.GetResponseMessage(invocation)}",
                                      stopWatch.ElapsedMilliseconds.ToString());
        }


        private string GetRequestMessage(IInvocation invocation)
        {
            if (!invocation.Arguments.Any())
                throw new ArgumentNullException(nameof(invocation));

            return jsonSerializer.JsonSerialize(invocation.Arguments[0]);
        }

        private string GetResponseMessage(IInvocation invocation)
        {
            if (!invocation.Arguments.Any())
                throw new ArgumentNullException(nameof(invocation));

            return jsonSerializer.JsonSerialize(invocation.ReturnValue);
        }

        private BaseRequestDto GetRequestDTOBase(IInvocation invocation)
        {
            if (!invocation.Arguments.Any())
                throw new ArgumentNullException(nameof(invocation));

            return invocation.Arguments[0] as BaseRequestDto;
        }

    }
}
