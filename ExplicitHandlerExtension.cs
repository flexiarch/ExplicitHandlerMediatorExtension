using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR.Extensions.ExplicitHandler
{
    public static class ExplicitHandlerExtension
    {
        /// <summary>
        /// Send a request to the explicitly specified handler.
        /// Extension make it easy to navigation in your project code. Specially when it is needed by code specification requirements.
        /// Usage: <code>Send(x => x.OfType&lt;YourRequestHandler&gt;(), requestObject, cancellationToken)</code>
        /// </summary>
        /// <typeparam name="TRequest">Mediator type IRequest of TResponse</typeparam>
        /// <typeparam name="TResponse">Response type</typeparam>
        /// <param name="mediator">IMediator interface to be extended</param>
        /// <param name="handlerSpecifier">Expressed contract handler selector. Using <code>x => x.OfType{YourRequestHandler}()</code></param>
        /// <param name="request">Request object pushed to the Mediator</param>
        /// <param name="cancellationToken">Task cancellation token (optional)</param>
        public static Task<TResponse> Send<TRequest, TResponse>(this IMediator mediator, Func<TypeSelector, IRequestHandler<TRequest, TResponse>> handlerSpecifier, TRequest request, CancellationToken cancellationToken = default(CancellationToken))
            where TRequest : IRequest<TResponse>
        {
            return mediator.Send(request, cancellationToken);
        }
    }

    /// <summary>
    /// Helper used by <seealso cref="ExplicitHandlerExtension.Send{TRequest, TResponse}(IMediator, Func{TypeSelector, IRequestHandler{TRequest, TResponse}}, TRequest, CancellationToken)"/> to resolve specified type contract handler
    /// </summary>
    public class TypeSelector
    {
        /// <summary>
        /// Type selector method
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <returns>Returns default T</returns>
        public T OfType<T>() => default(T);
    }
}
