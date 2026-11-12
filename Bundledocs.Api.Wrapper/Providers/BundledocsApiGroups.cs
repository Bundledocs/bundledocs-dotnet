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

        public Task<Group[]> GetGroupsAsync(CancellationToken cancellationToken)
        {
            return _requestProvider.GetListAsync<Group>("/groups", cancellationToken);
        }

        public Task<GroupMember[]> GetGroupMembersAsync(string partitionKey, string rowKey, CancellationToken cancellationToken)
        {
            return _requestProvider.GetListAsync<GroupMember>($"/groups/{partitionKey}/{rowKey}/members", cancellationToken);
        }
    }
}
