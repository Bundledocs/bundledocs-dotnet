using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Bundledocs.Api.Wrapper.Test")]

namespace Bundledocs.Api.Wrapper
{
    using Bundledocs.Api.Wrapper.Interfaces;
    using Bundledocs.Api.Wrapper.Providers;
    using System;

    /// <summary>
    /// Single entry point for consuming the Bundledocs API.
    /// Provides access to Users, Groups, and Briefs and other endpoints through a unified, authenticated client.
    /// Implements <see cref="IDisposable"/> to release the underlying HTTP resources when no longer needed.
    /// </summary>
    public sealed class BundledocsApiClient : IBundledocsApi, IDisposable
    {
        private readonly BundledocsApiRequestProvider _requestProvider;

        /// <summary>
        /// Creates a new API client authenticated with the supplied access token.
        /// </summary>
        /// <param name="apiBasePath">The base URL of the Bundledocs API (e.g. "https://app.bundledocs.com/api/v1").</param>
        /// <param name="accessToken">A valid OAuth 2.0 Bearer access token.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="apiBasePath"/> or <paramref name="accessToken"/> is null or empty.</exception>
        public BundledocsApiClient(string apiBasePath, string accessToken)
        {
            if (String.IsNullOrWhiteSpace(apiBasePath))
            {
                throw new ArgumentException("API base path cannot be null or empty.", nameof(apiBasePath));
            }

            if (String.IsNullOrWhiteSpace(accessToken))
            {
                throw new ArgumentException("Access token cannot be null or empty.", nameof(accessToken));
            }

            _requestProvider = new BundledocsApiRequestProvider(apiBasePath, accessToken);
            Users = new BundledocsApiUsers(_requestProvider);
            Groups = new BundledocsApiGroups(_requestProvider);
            Briefs = new BundledocsApiBriefs(_requestProvider);
        }

        public IBundledocsApiUsers Users { get; }

        public IBundledocsApiGroups Groups { get; }

        public IBundledocsApiBriefs Briefs { get; }

        public void Dispose()
        {
            _requestProvider?.Dispose();
        }
    }
}
