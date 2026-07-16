namespace Bundledocs.Api.Wrapper.Providers
{
    public class BundledocsApiPostParameters
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public object AdditionalData { get; set; }
    }
}
