namespace Bundledocs.Api.Wrapper.Interfaces
{
    using Bundledocs.Api.Wrapper.Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides operations for managing groups and group memberships.
    /// </summary>
    public interface IBundledocsApiGroups
    {
        /// <summary>
        /// Retrieves all groups accessible to the authenticated user.
        /// </summary>
        /// <param name="cancellationToken">Cancels the request.</param>
        Task<Group[]> GetGroupsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves the members of a specific group.
        /// </summary>
        /// <param name="partitionKey">The partition key of the group.</param>
        /// <param name="rowKey">The row key of the group.</param>
        /// <param name="cancellationToken">Cancels the request.</param>
        Task<GroupMember[]> GetGroupMembersAsync(string partitionKey, string rowKey, CancellationToken cancellationToken = default);
    }
}
