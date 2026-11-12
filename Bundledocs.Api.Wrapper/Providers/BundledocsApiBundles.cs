namespace Bundledocs.Api.Wrapper.Providers
{
    using Bundledocs.Api.Wrapper.Interfaces;
    using Bundledocs.Api.Wrapper.Models;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class BundledocsApiBundles : IBundledocsApiBundles
    {
        private readonly IBundledocsApiRequestProvider _requestProvider;

        internal BundledocsApiBundles(IBundledocsApiRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task<BundleMigrationInvitation> SendMigrationInvitationAsync(string partitionKey, string rowKey, BundleMigrationInvitationCreateOptions options, CancellationToken cancellationToken)
        {
            return _requestProvider.PostAsync<BundleMigrationInvitationCreateOptions, BundleMigrationInvitation>($"/bundles/{partitionKey}/{rowKey}/migrations", options, cancellationToken);
        }

        public Task<BundleMigrationInvitation[]> GetMigrationInvitationsAsync(string partitionKey, string rowKey, CancellationToken cancellationToken)
        {
            return _requestProvider.GetListAsync<BundleMigrationInvitation>($"/bundles/{partitionKey}/{rowKey}/migrations", cancellationToken);
        }
    }
}
