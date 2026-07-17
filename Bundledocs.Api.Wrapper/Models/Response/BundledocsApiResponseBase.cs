namespace Bundledocs.Api.Wrapper.Models
{
    using System;

    public class BundledocsApiResponseBase
    {
        /*System*/
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTime Created { get; set; }
    }
}
