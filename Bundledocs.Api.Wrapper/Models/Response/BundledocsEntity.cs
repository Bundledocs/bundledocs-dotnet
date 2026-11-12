namespace Bundledocs.Api.Wrapper.Models
{
    using System;

    public class BundledocsEntity
    {
        /*System*/
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastAccessedTimeStamp { get; set; }
        public string ForeignKey { get; set; }
        public bool IsDeleted { get; set; }
    }
}
