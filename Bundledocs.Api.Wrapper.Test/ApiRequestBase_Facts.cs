namespace Bundledocs.Api.Wrapper.Test
{
    using System;

    public class ApiRequestBase_Facts : IDisposable
    {
        protected BundledocsApiClient _client;

        public ApiRequestBase_Facts()
        {
            string serverName = URLConstant.URLFormat.SERVER;
            string accessToken = ResolveEnvironmentVariable("BUNDLEDOCS_ACCESS_TOKEN");
            _client = new BundledocsApiClient(serverName, accessToken);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

        protected static string ResolveEnvironmentVariable(string variableName)
        {
            string value = Environment.GetEnvironmentVariable(variableName);

            if (String.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException(
                    $"Environment variable '{variableName}' is not set.\n" +
                    $"Set it via: set {variableName}=<value>");
            }

            return value;
        }
    }
}
