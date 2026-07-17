namespace Bundledocs.Api.Wrapper.Test
{
    using System;
    using Bundledocs.Api.Wrapper.Providers;

    public class ApiRequestBase_Facts
    {
        internal BundledocsApiRequestProvider _bundledocsApiGetRequestProvider;

        public ApiRequestBase_Facts()
        {
            string serverName = Environment.GetEnvironmentVariable("BUNDLEDOCS_API_URL")
                                ?? "https://app.bundledocs.com/api/v1";
            string accessToken = Environment.GetEnvironmentVariable("BUNDLEDOCS_ACCESS_TOKEN")
                                 ?? throw new InvalidOperationException("BUNDLEDOCS_ACCESS_TOKEN environment variable is not set.");
            _bundledocsApiGetRequestProvider = new BundledocsApiRequestProvider(serverName, accessToken);
        }
    }
}
