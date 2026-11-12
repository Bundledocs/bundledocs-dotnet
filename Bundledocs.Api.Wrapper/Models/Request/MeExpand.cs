namespace Bundledocs.Api.Wrapper.Models
{
    /// <summary>
    /// Values supported by <see cref="MeRequestOptions.Expand"/>.
    /// </summary>
    public static class MeExpand
    {
        /// <summary>
        /// Includes the bundles of the user in the response (<see cref="User.Briefs"/>).
        /// </summary>
        public const string Bundles = "user.briefs";
    }
}
