namespace Bundledocs.Api.Wrapper.Providers
{
    using Bundledocs.Api.Wrapper.Interfaces;
    using Bundledocs.Api.Wrapper.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class BundledocsApiUsers : IBundledocsApiUsers
    {
        private const string MeEndpoint = "/users/me";

        private readonly IBundledocsApiRequestProvider _requestProvider;

        internal BundledocsApiUsers(IBundledocsApiRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public Task<User> GetMeAsync(MeRequestOptions options, CancellationToken cancellationToken)
        {
            return _requestProvider.GetAsync<User>(BuildMeEndpoint(options), cancellationToken);
        }

        // the API has no expand parameter: /users/me includes the bundles and /users/me/lazy does not
        private static string BuildMeEndpoint(MeRequestOptions options)
        {
            IEnumerable<string> expand = options?.Expand ?? Enumerable.Empty<string>();
            bool expandBundles = expand.Any(value => string.Equals(value?.Trim(), MeExpand.Bundles, StringComparison.OrdinalIgnoreCase));

            return expandBundles ? MeEndpoint : MeEndpoint + "/lazy";
        }
    }
}
