namespace Bundledocs.Api.Wrapper.Models
{
    public class BundleVisibleTo : BundledocsEntity
    {
        public int Role { get; set; }

        public string VisibleToPartitionKey { get; set; }
        public string VisibleToRowKey { get; set; }
    }
}
