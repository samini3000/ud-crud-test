using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FRD.Application
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IApplicationRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Requset started: {typeof(TRequest).Name} - {JsonConvert.SerializeObject(request)}");
            var response = await next();
            _logger.LogInformation($"Requset finished: {typeof(TRequest).Name} - {JsonConvert.SerializeObject(request)}");

            return response;
        }
    }

}


