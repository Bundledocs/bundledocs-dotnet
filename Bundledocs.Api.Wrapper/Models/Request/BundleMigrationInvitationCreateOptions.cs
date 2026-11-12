namespace Bundledocs.Api.Wrapper.Models
{
    using System;

    /// <summary>
    /// Options for <c>Bundles.SendMigrationInvitationAsync</c>.
    /// </summary>
    public class BundleMigrationInvitationCreateOptions
    {
        /// <summary>
        /// E-mail address of the user who will receive the bundle.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Date when the invitation stops being valid.
        /// </summary>
        public DateTime ExpiryDate { get; set; }
    }
}
