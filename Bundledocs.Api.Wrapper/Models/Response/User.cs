namespace Bundledocs.Api.Wrapper.Models
{
    using System;
    using System.Collections.Generic;

    public class User : BundledocsEntity
    {
        /*System*/
        public string Type { get; set; }
        public string Domain { get; set; }
        public string EmailGroup { get; set; }

        /*Identity*/
        public string Email { get; set; }

        /*Security*/
        public int SessionIdleTimeout { get; set; }

        /*Personal*/
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Company { get; set; }

        /*Role*/
        public int UserRole { get; set; }

        /*Adjust*/
        public string AdjustBundleRowKey { get; set; }

        /*Locale*/
        public string Locale { get; set; }
        public string TimeZoneId { get; set; }
        public string CountryCode { get; set; }
        public string VatNumber { get; set; }

        /*Brief Globals*/
        public string BriefIndexTitleText { get; set; }
        public string BriefIndexPageNumberHeaderText { get; set; }
        public string BriefIndexDisplayDateHeaderText { get; set; }
        public string BriefIndexCustomColumnHeaderText { get; set; }

        public string BriefDisplayDateFormat { get; set; }
        public string BriefLateInsertSeparator { get; set; }

        public bool IsUsingSourceFileDimensions { get; set; }
        public bool IsBriefVerifiedBeforeGenerating { get; set; }
        public bool IsUsingEmailAttachments { get; set; }
        public bool IsVisibleToGroups { get; set; }

        public int BriefZoomLevel { get; set; }
        public int BriefPageSize { get; set; }

        public string BriefBlobStorageAccountName { get; set; }
        public bool IsBriefBlobStorageAccountNameReadOnly { get; set; }

        public bool IsUsingMaxDpiOnUpload { get; set; }
        public bool IsUsingMaxDpiOnGenerate { get; set; }

        public string DefaultTemplateRowKey { get; set; }

        /*Font & Style*/
        public string BriefSectionIndexFontType { get; set; }
        public string BriefSectionIndexFontSize { get; set; }
        public string BriefSectionIndexFontColor { get; set; }

        public string BriefDocumentIndexFontType { get; set; }
        public string BriefDocumentIndexFontSize { get; set; }
        public string BriefDocumentIndexFontColor { get; set; }

        public string BriefPageNumberFontType { get; set; }
        public string BriefPageNumberFontSize { get; set; }
        public string BriefPageNumberFontColor { get; set; }

        public string BriefSectionBorderColor { get; set; }

        /*Notifications*/
        public bool IsSendEmailBriefGenerated { get; set; }
        public bool IsSendEmailBriefDeleted { get; set; }
        public DateTime NotificationsLastReadTimeStamp { get; set; }

        /*Metadata*/
        public Dictionary<string, string> Metadata { get; set; }

        /*PinnedBriefs*/
        public List<UserPinnedBundle> PinnedBriefs { get; set; }

        /*External*/
        public string ClioDomainEndpoint { get; set; }
        public string NetDocumentsDomainEndpoint { get; set; }
        public string IkenDomainEndpoint { get; set; }
        public string MFilesDomainEndpoint { get; set; }
        public string MFilesVaultGuid { get; set; }
        public int SmokeballDomainEndpoint { get; set; }

        /*Subscriptions*/
        public string StripeSubscriberKey { get; set; }
        public string StripeSubscriberPlanKey { get; set; }
        public string StripeSubscriberPlanDescription { get; set; }
        public string StripeSubscriberCurrencyCode { get; set; }

        /*Features*/
        public int FeatureStatusAdjust { get; set; }
        public int FeatureStatusEdit { get; set; }
        public int FeatureStatusDocumentIntelligence { get; set; }
        public int FeatureStatusReview { get; set; }
        public int FeatureStatusBundleSearch { get; set; }
        public int FeatureStatusBundleFacts { get; set; }
        public int FeatureRestrictUnlicensedCollaborators { get; set; }
        public int FeatureStatusDownloadRedirect { get; set; }

        /*OneToMany*/
        public List<Bundle> Briefs { get; set; }
    }
}
