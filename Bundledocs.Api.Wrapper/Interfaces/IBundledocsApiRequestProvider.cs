namespace Bundledocs.Api.Wrapper.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Internal abstraction over HTTP operations.
    /// Decouples the API providers (Users, Groups, Bundles and etc) from the concrete HTTP implementation.
    /// </summary>
    internal interface IBundledocsApiRequestProvider
    {
        Task<T> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default);
        Task<T[]> GetListAsync<T>(string endpoint, CancellationToken cancellationToken = default);
        Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest body = default, CancellationToken cancellationToken = default);
    }
}
