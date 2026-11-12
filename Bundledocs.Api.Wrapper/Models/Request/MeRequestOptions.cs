namespace Bundledocs.Api.Wrapper.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Options for the <c>Me</c> request. By default a lightweight profile is returned.
    /// </summary>
    public class MeRequestOptions
    {
        /// <summary>
        /// Additional data to expand in the response. Use the values in <see cref="MeExpand"/>.
        /// Case and surrounding spaces are ignored. Unknown values are ignored, as the API does.
        /// </summary>
        public IList<string> Expand { get; set; } = new List<string>();
    }
}
