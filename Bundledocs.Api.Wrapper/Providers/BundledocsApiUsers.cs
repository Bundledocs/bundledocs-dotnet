namespace Bundledocs.Api.Wrapper.Providers
{
    using Bundledocs.Api.Wrapper.Interfaces;
    using Bundledocs.Api.Wrapper.Models;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class BundledocsApiUsers : IBundledocsApiUsers
    {
        private readonly IBundledocsApiRequestProvider _requestProvider;

        internal BundledocsApiUsers(IBundledocsApiRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task<BundledocsApiResponseUser> Me(CancellationToken cancellationToken = default)
        {
            return _requestProvider.Get<BundledocsApiResponseUser>("/users/me", cancellationToken);
        }

        public Task<BundledocsApiResponseUser> MeLazy(CancellationToken cancellationToken = default)
        {
            return _requestProvider.Get<BundledocsApiResponseUser>("/users/me/lazy", cancellationToken);
        }
    }
}
