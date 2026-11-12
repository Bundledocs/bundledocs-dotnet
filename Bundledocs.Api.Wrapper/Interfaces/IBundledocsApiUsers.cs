namespace Bundledocs.Api.Wrapper.Interfaces
{
    using Bundledocs.Api.Wrapper.Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides operations for the authenticated user's profile.
    /// </summary>
    public interface IBundledocsApiUsers
    {
        /// <summary>
        /// Retrieves a lightweight profile of the currently authenticated user (without bundles).
        /// Use <paramref name="options"/> to expand additional data (see <see cref="MeExpand"/>).
        /// </summary>
        /// <param name="options">Additional data to include in the response.</param>
        /// <param name="cancellationToken">Cancels the request.</param>
        Task<User> GetMeAsync(MeRequestOptions options = null, CancellationToken cancellationToken = default);
    }
}
