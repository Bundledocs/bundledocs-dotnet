namespace Bundledocs.Api.Wrapper.Models
{
    public class BundledocsApiResponseBriefMigrationInvitation : BundledocsApiResponseBase
    {
        public string DestinationUserEmail { get; set; }
        public bool IsAccepted { get; set; }
        public string Signature { get; set; }
    }
}
