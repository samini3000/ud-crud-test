using MediatR;

namespace FRD.Application
{
    public interface IApplicationRequest<T> : IRequest<T>
    {
    }
}
