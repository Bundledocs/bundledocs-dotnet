namespace Bundledocs.Api.Wrapper.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Internal abstraction over HTTP operations.
    /// Decouples the API providers (Users, Groups, Briefs and etc) from the concrete HTTP implementation.
    /// </summary>
    internal interface IBundledocsApiRequestProvider
    {
        Task<T> Get<T>(string endpoint, CancellationToken cancellationToken = default);
        Task<T[]> GetList<T>(string endpoint, CancellationToken cancellationToken = default);
        Task<TResponse> Post<TRequest, TResponse>(string endpoint, TRequest body = default, CancellationToken cancellationToken = default);
    }
}
