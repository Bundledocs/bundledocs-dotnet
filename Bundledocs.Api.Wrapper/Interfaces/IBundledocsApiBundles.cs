namespace Bundledocs.Api.Wrapper.Interfaces
{
    using Bundledocs.Api.Wrapper.Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides operations related to bundles.
    /// </summary>
    public interface IBundledocsApiBundles
    {
        /// <summary>
        /// Sends a migration invitation for the specified bundle.
        /// </summary>
        /// <param name="partitionKey">The partition key of the bundle.</param>
        /// <param name="rowKey">The row key of the bundle.</param>
        /// <param name="options">The invitation details.</param>
        /// <param name="cancellationToken">Cancels the request.</param>
        Task<BundleMigrationInvitation> SendMigrationInvitationAsync(string partitionKey, string rowKey, BundleMigrationInvitationCreateOptions options, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all migration invitations for the specified bundle.
        /// </summary>
        /// <param name="partitionKey">The partition key of the bundle.</param>
        /// <param name="rowKey">The row key of the bundle.</param>
        /// <param name="cancellationToken">Cancels the request.</param>
        Task<BundleMigrationInvitation[]> GetMigrationInvitationsAsync(string partitionKey, string rowKey, CancellationToken cancellationToken = default);
    }
}
