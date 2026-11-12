namespace Bundledocs.Api.Wrapper.Providers
{
    using Bundledocs.Api.Wrapper.Exceptions;
    using Bundledocs.Api.Wrapper.Interfaces;
    using Bundledocs.Api.Wrapper.Models;
    using RestSharp;
    using RestSharp.Authenticators.OAuth2;
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Internal HTTP provider that executes requests against the Bundledocs API using RestSharp.
    /// Handles JSON deserialization, envelope unwrapping, and centralized error handling.
    /// </summary>
    internal sealed class BundledocsApiRequestProvider : IBundledocsApiRequestProvider, IDisposable
    {
        private readonly RestClient _client;

        private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        internal BundledocsApiRequestProvider(string apiBasePath, string accessToken)
        {
            // the HttpClient is shared by every client with the same base URL, so per-client settings such as the token belong in these options
            RestClientOptions options = new RestClientOptions
            {
                BaseUrl = new Uri(apiBasePath),
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken, "Bearer")
            };

            _client = new RestClient(options, useClientFactory: true);
        }

        public async Task<T> GetAsync<T>(string endpoint, CancellationToken cancellationToken)
        {
            RestRequest request = new RestRequest(endpoint, Method.Get);
            RestResponse response = await _client.ExecuteGetAsync(request, cancellationToken).ConfigureAwait(false);

            EnsureSuccess(endpoint, response);

            if (String.IsNullOrWhiteSpace(response.Content))
            {
                throw new BundledocsApiException(
                    $"Request to '{endpoint}' succeeded but returned no content.",
                    response.StatusCode,
                    response.Content);
            }

            BundledocsApiResponse<T> apiResponse = JsonSerializer.Deserialize<BundledocsApiResponse<T>>(response.Content, _serializerOptions);

            if (apiResponse?.Data == null || apiResponse.Data.Count == 0)
            {
                throw new BundledocsApiException(
                    $"Request to '{endpoint}' succeeded but the response contained no data.",
                    response.StatusCode,
                    response.Content);
            }

            return apiResponse.Data[0];
        }

        public async Task<T[]> GetListAsync<T>(string endpoint, CancellationToken cancellationToken)
        {
            RestRequest request = new RestRequest(endpoint, Method.Get);
            RestResponse response = await _client.ExecuteGetAsync(request, cancellationToken).ConfigureAwait(false);

            EnsureSuccess(endpoint, response);

            if (String.IsNullOrWhiteSpace(response.Content))
            {
                return Array.Empty<T>();
            }

            BundledocsApiResponse<List<T>> apiResponse = JsonSerializer.Deserialize<BundledocsApiResponse<List<T>>>(response.Content, _serializerOptions);

            if (apiResponse?.Data == null || apiResponse.Data.Count == 0)
            {
                return Array.Empty<T>();
            }

            return apiResponse.Data[0].ToArray();
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest body, CancellationToken cancellationToken)
        {
            RestRequest request = new RestRequest(endpoint, Method.Post);

            if (body != null)
            {
                request.AddJsonBody((object)body);
            }

            RestResponse response = await _client.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);

            EnsureSuccess(endpoint, response);

            if (String.IsNullOrWhiteSpace(response.Content))
            {
                throw new BundledocsApiException(
                    $"Request to '{endpoint}' succeeded but returned no content.",
                    response.StatusCode,
                    response.Content);
            }

            BundledocsApiResponse<TResponse> apiResponse = JsonSerializer.Deserialize<BundledocsApiResponse<TResponse>>(response.Content, _serializerOptions);

            if (apiResponse?.Data == null || apiResponse.Data.Count == 0)
            {
                throw new BundledocsApiException(
                    $"Request to '{endpoint}' succeeded but the response contained no data.",
                    response.StatusCode,
                    response.Content);
            }

            return apiResponse.Data[0];
        }

        private static void EnsureSuccess(string endpoint, RestResponse response)
        {
            if (!response.IsSuccessful)
            {
                throw new BundledocsApiException(
                    $"Request to '{endpoint}' failed with status code {(int)response.StatusCode} ({response.StatusCode}).",
                    response.StatusCode,
                    response.Content);
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
