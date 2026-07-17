namespace Bundledocs.Api.Wrapper.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    internal class BundledocsApiResponse<T>
    {
        [JsonPropertyName("errors")]
        public List<BundledocsApiResponseMessage> Errors { get; set; } = new List<BundledocsApiResponseMessage>();

        [JsonPropertyName("messages")]
        public List<BundledocsApiResponseMessage> Messages { get; set; } = new List<BundledocsApiResponseMessage>();

        [JsonPropertyName("data")]
        public List<T> Data { get; set; } = new List<T>();
    }
}
