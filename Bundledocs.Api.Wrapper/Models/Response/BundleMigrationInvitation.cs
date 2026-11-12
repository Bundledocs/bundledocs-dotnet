namespace Bundledocs.Api.Wrapper.Models
{
    using System;

    public class BundleMigrationInvitation : BundledocsEntity
    {
        public string DestinationUserEmail { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string DestinationUserRowKey { get; set; }
        public bool IsAccepted { get; set; }
        public string Signature { get; set; }
    }
}
