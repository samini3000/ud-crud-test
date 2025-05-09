using MediatR;
using Microsoft.Extensions.Logging;

namespace FRD.Application
{
    public class ExceptionHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IApplicationRequest<TResponse>
    {
        private readonly ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> _logger;

        public ExceptionHandlingBehavior(ILogger<ExceptionHandlingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response = Activator.CreateInstance<TResponse>();
            try
            {
                response = await next();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Exception in  Handling {typeof(TRequest).Name} : {e.Message}");
                throw;
            }

            return response;
        }
    }
}


