namespace Bundledocs.Api.Wrapper.Interfaces
{
    using Bundledocs.Api.Wrapper.Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides operations related to bundles (briefs).
    /// </summary>
    public interface IBundledocsApiBriefs
    {
        /// <summary>
        /// Options required to create a bundle migration invitation.
        /// </summary>
        public record class BriefMigrationInvitationCreateOptions(
            string Email,
            DateTime ExpiryDate
        );

        /// <summary>
        /// Sends a migration invitation for the specified bundle.
        /// </summary>
        /// <param name="partitionKey">The partition key of the bundle.</param>
        /// <param name="rowKey">The row key of the bundle.</param>
        /// <param name="options">The invitation details.</param>
        Task<BundledocsApiResponseBriefMigrationInvitation> SendBundleMigrationInvitation(string partitionKey, string rowKey, BriefMigrationInvitationCreateOptions options, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all migration invitations for the specified bundle.
        /// </summary>
        /// <param name="partitionKey">The partition key of the bundle.</param>
        /// <param name="rowKey">The row key of the bundle.</param>
        Task<BundledocsApiResponseBriefMigrationInvitation[]> GetBundleMigrations(string partitionKey, string rowKey, CancellationToken cancellationToken = default);
    }
}
