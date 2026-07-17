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
        /// Retrieves the full profile of the currently authenticated user.
        /// </summary>
        Task<BundledocsApiResponseUser> Me(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a lightweight profile of the currently authenticated user.
        /// </summary>
        Task<BundledocsApiResponseUser> MeLazy(CancellationToken cancellationToken = default);
    }
}
