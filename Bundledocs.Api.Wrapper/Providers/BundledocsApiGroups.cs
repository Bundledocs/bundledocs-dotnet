namespace Bundledocs.Api.Wrapper.Providers
{
    using Bundledocs.Api.Wrapper.Interfaces;
    using Bundledocs.Api.Wrapper.Models;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class BundledocsApiGroups : IBundledocsApiGroups
    {
        private readonly IBundledocsApiRequestProvider _requestProvider;

        internal BundledocsApiGroups(IBundledocsApiRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task<BundledocsApiResponseGroup[]> GetGroups(CancellationToken cancellationToken)
        {
            return _requestProvider.GetList<BundledocsApiResponseGroup>("/groups", cancellationToken);
        }

        public Task<BundledocsApiResponseGroupMember[]> GetGroupMembers(string partitionKey, string rowKey, CancellationToken cancellationToken)
        {
            return _requestProvider.GetList<BundledocsApiResponseGroupMember>($"/groups/{partitionKey}/{rowKey}/members", cancellationToken);
        }
    }
}
