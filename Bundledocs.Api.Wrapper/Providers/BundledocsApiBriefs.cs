namespace Bundledocs.Api.Wrapper.Providers
{
    using Bundledocs.Api.Wrapper.Interfaces;
    using Bundledocs.Api.Wrapper.Models;
    using System.Threading;
    using System.Threading.Tasks;
    using static Bundledocs.Api.Wrapper.Interfaces.IBundledocsApiBriefs;

    internal sealed class BundledocsApiBriefs : IBundledocsApiBriefs
    {
        private readonly IBundledocsApiRequestProvider _requestProvider;

        internal BundledocsApiBriefs(IBundledocsApiRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task<BundledocsApiResponseBriefMigrationInvitation> SendBundleMigrationInvitation(string partitionKey, string rowKey, BriefMigrationInvitationCreateOptions options, CancellationToken cancellationToken)
        {
            return _requestProvider.Post<BriefMigrationInvitationCreateOptions, BundledocsApiResponseBriefMigrationInvitation>($"/bundles/{partitionKey}/{rowKey}/migrations", options, cancellationToken);
        }

        public Task<BundledocsApiResponseBriefMigrationInvitation[]> GetBundleMigrations(string partitionKey, string rowKey, CancellationToken cancellationToken)
        {
            return _requestProvider.GetList<BundledocsApiResponseBriefMigrationInvitation>($"/bundles/{partitionKey}/{rowKey}/migrations",cancellationToken);
        }
    }
}
