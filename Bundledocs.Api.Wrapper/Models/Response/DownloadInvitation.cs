namespace Bundledocs.Api.Wrapper.Models
{
    using System;

    public class DownloadInvitation : BundledocsEntity
    {
        public DateTime ExpiryDate { get; set; }
        public int ExpiryDownloadLimit { get; set; }
        public int ExpiryDownloadCount { get; set; }
        public string Email { get; set; }
        public int ResourceType { get; set; }
        public string ActionUri { get; set; }
    }
}
