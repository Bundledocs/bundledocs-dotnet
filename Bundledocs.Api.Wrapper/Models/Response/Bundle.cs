namespace Bundledocs.Api.Wrapper.Models
{
    using System.Collections.Generic;

    public class Bundle : BundledocsEntity
    {
        /*Legacy (always empty in the API)*/
        public string PdfFilePath { get; set; }
        public bool IsPageNumberPrintedOnTitlePages { get; set; }

        public long PdfFileLength { get; set; }

        public bool IsLocked { get; set; }
        public int GenerateStatus { get; set; }

        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string IndexTitleText { get; set; }
        public string IndexPageNumberHeaderText { get; set; }
        public string IndexDisplayDateHeaderText { get; set; }
        public string IndexCustomColumnHeaderText { get; set; }
        public string LateInsertSeparator { get; set; }
        public string LateInsertFormat { get; set; }
        public bool IsLateInsertSeparatorDisplayOrderEnabled { get; set; }
        public string LateInsertSeparatorDisplayOrder { get; set; }

        public bool IsBriefSectionHeadersIncluded { get; set; }
        public bool IsSectionIndexPagesRemoved { get; set; }
        public int SectionHierarchyLevelDisplay { get; set; }
        public bool IsSuperIndexPagesRemoved { get; set; }
        public bool IsSuperTitlePageRemoved { get; set; }

        /*View Options*/
        public bool IsBriefDocumentDisplayDateVisibleInTree { get; set; }
        public bool IsBriefDocumentCustomColumnTextVisibleInTree { get; set; }
        public bool IsBriefDocumentXRefVisibleInTree { get; set; }
        public bool IsBatesStampVisibleInTree { get; set; }

        /*Display Date*/
        public bool IsBriefDocumentDisplayDateVisibleInIndex { get; set; }

        public bool IsPageNumberingResetPerBook { get; set; }

        public bool IsPageNumberPrintedOnAllPages { get; set; }
        public bool IsPageNumberPrintedOnIndexPages { get; set; }
        public bool IsPageNumberPrintedOnIndexPagesGlobal { get; set; }

        public bool IsPageNumberPrintedOnGlobalTitlePage { get; set; }
        public bool IsPageNumberPrintedOnIndexPagesSeparate { get; set; }
        public int PageNumberPrintedOnIndexPagesSeparateStyle { get; set; }
        public string PageNumberPrintedOnIndexPagesSeparatePrefix { get; set; }
        public int PageNumberPrintedOnIndexPagesSeparatePrefixStartNumber { get; set; }
        public int PageNumberPrintedOnIndexPagesSeparateStartNumber { get; set; }
        public int PageNumberPrintedOnIndexPagesSeparateResetNumber { get; set; }

        public bool IsPageNumberSuppressedOnDocuments { get; set; }
        public bool IsPageNumberSuppressedOnIndexPages { get; set; }

        public bool IsPageNumberPrefixedWithSectionNumber { get; set; }

        public bool IsSectionNumberNumeric { get; set; }
        public int SectionNumberStart { get; set; }

        public int DocumentNumberStart { get; set; }

        public bool IsLateInsertNumberNumeric { get; set; }
        public bool IsLateInsertPageNumberNumeric { get; set; }

        public bool IsDisplayOrderHiddenDocument { get; set; }
        public bool IsDisplayOrderHiddenSection { get; set; }
        public bool IsDisplayOrderHiddenVolume { get; set; }
        public bool IsMarkdownSyntaxEnabled { get; set; }

        public string PageNumberingPositionVertical { get; set; }
        public string PageNumberingPositionHorizontal { get; set; }

        /*Document Description*/
        public bool IsDocumentDescriptionPrintedOnDocuments { get; set; }
        public int DocumentDescriptionSource { get; set; }
        public string DocumentDescriptionSourceCode { get; set; }
        public string DocumentDescriptionPositionVertical { get; set; }
        public string DocumentDescriptionPositionHorizontal { get; set; }

        /*Bookmark Description*/
        public int BookmarkDescriptionSource { get; set; }
        public string BookmarkDescriptionSourceCode { get; set; }
        public int BookmarkDescriptionSectionSource { get; set; }
        public string BookmarkDescriptionSectionSourceCode { get; set; }

        public int BookmarkDisplayType { get; set; }

        public bool IsGenerateWithPageLabels { get; set; }

        public bool IsGenerateWithInternalDocumentBookmarks { get; set; }
        public bool IsGenerateWithAnnotationBookmarks { get; set; }

        public bool IsDisplayOrderGlobal { get; set; }
        public bool IsDisplayOrderGlobalAllLevels { get; set; }
        public bool IsDisplayOrderGlobalDocumentsOnly { get; set; }
        public bool IsDisplayOrderGlobalRestartRoot { get; set; }

        public bool IsSplitAndZip { get; set; }
        public bool IsSourceAndZip { get; set; }
        public bool IsZipWithSubFolders { get; set; }
        public bool IsZipWithFullBundle { get; set; }
        public bool IsZipWithAlternativeIndex { get; set; }
        public int ZipIndexSourceContainer { get; set; }
        public int ZipIndexHyperlinkType { get; set; }
        public bool IsGenerateWithSplitPoints { get; set; }
        public int PdfAComplianceLevel { get; set; }

        public bool IsGenerateWithVolumes { get; set; }
        public bool IsGenerateWithoutDocuments { get; set; }
        public bool IsGenerateWithoutDocumentsQuickView { get; set; }

        public bool IsGenerateWithSlipsheets { get; set; }
        public bool IsGenerateWithSlipsheetsOnSubDocuments { get; set; }
        public bool IsPageNumberPrintedOnSlipsheets { get; set; }

        public bool IsGenerateWithVacatPages { get; set; }
        public bool IsGenerateWithVacatPagesDocuments { get; set; }
        public bool IsPageNumberPrintedSingleSided { get; set; }

        public bool IsPageNumberPrintedOnVacatPages { get; set; }

        public bool IsGenerateWithLateInsertsOnly { get; set; }
        public bool IsGenerateWithCustomColumnText { get; set; }
        public bool IsGenerateWithDocumentTags { get; set; }
        public int DocumentTagsPageNumber { get; set; }
        public string PageNumberingPositionVerticalCoreBundle { get; set; }
        public string PageNumberingPositionHorizontalCoreBundle { get; set; }

        public List<BundleDocument> BriefDocuments { get; set; }
        public List<BundleReceipt> BriefReceipts { get; set; }
        public List<BundleShare> BriefShares { get; set; }
        public List<BundleCollaborator> BriefCollaborators { get; set; }
        public List<BundleVisibleTo> BriefVisibleTos { get; set; }

        public BundleMigrationInvitation MigrationInvitation { get; set; }

        public bool IsBatesPageNumberIncluded { get; set; }
        public string BatesPageNumberPrefix { get; set; }
        public string BatesPageNumberSuffix { get; set; }
        public int BatesPageNumberStart { get; set; }
        public int BatesPageNumberLength { get; set; }
        public int BatesPageNumberBehavior { get; set; }
        public string BatesPageNumberPositionVertical { get; set; }
        public string BatesPageNumberPositionHorizontal { get; set; }

        public bool IsWatermarked { get; set; }
        public string WatermarkType { get; set; }

        /*Content Optimizations*/
        public bool IsUsingMaxDpiOnUpload { get; set; }
        public int MaxDpiOnUpload { get; set; }
        public bool IsUsingMaxDpiOnGenerate { get; set; }
        public int MaxDpiOnGenerate { get; set; }

        /*Content Conversion*/
        public bool IsUsingSourceOrientationOnUpload { get; set; }
        public bool IsUsingRemovePreviousCorrespondenceOnUpload { get; set; }
        public bool IsUsingSourceAnnotationsOnUpload { get; set; }

        public bool IsUsingOcrOnUpload { get; set; }
        public bool IsUsingLockedOnUpload { get; set; }
        public bool IsUsingEmailMetadataOnUpload { get; set; }
        public bool IsUsingAutomaticDatesOnUpload { get; set; }

        /*Annotations*/
        public bool IsRedactionsExcludedGlobal { get; set; }
        public bool IsRedactionsIndicative { get; set; }
        public bool IsHighlightsExcludedGlobal { get; set; }
        public bool IsNotesExcludedGlobal { get; set; }
        public bool IsLabelsExcludedGlobal { get; set; }

        public int BriefAnnotationExclusionPolicy { get; set; }
        public List<BundleAnnotationExclusion> BriefAnnotationExclusions { get; set; }

        public bool IsGenerateWithPrivateAnnotations { get; set; }

        public int BriefPageNumberHorizontalOffset { get; set; }
        public int BriefPageNumberVerticalOffset { get; set; }

        /*Groups & Sharing*/
        public bool IsBriefOpen { get; set; }
        public bool IsVisibleToGroups { get; set; }
        public bool IsReadOnlyToGroups { get; set; }
        public string DefaultBriefGroupRowKey { get; set; }
        public int UserAccessPolicy { get; set; }

        public int AccessType { get; set; }
        public bool IsHidden { get; set; }

        public string TemplatePartitionKey { get; set; }
        public string TemplateRowKey { get; set; }

        public string BriefDocumentDisplayDateFormat { get; set; }

        /*Font*/
        public string SectionIndexFontSize { get; set; }
        public string SectionIndexFontType { get; set; }
        public string SectionIndexFontColor { get; set; }

        public string DocumentIndexFontSize { get; set; }
        public string DocumentIndexFontType { get; set; }
        public string DocumentIndexFontColor { get; set; }

        public string PageNumberFontType { get; set; }
        public string PageNumberFontSize { get; set; }
        public string PageNumberFontColor { get; set; }

        public string DocumentDescriptionFontType { get; set; }
        public string DocumentDescriptionFontSize { get; set; }
        public string DocumentDescriptionFontColor { get; set; }

        /*Section*/
        public string SectionBorderColor { get; set; }

        /*Zipped Bundles*/
        public int SectionZipIndexSourceSection { get; set; }
        public string SectionZipIndexSourceCodeSection { get; set; }
        public int SectionZipIndexSource { get; set; }
        public string SectionZipIndexSourceCode { get; set; }

        public int ZoomLevel { get; set; }

        public int PageSize { get; set; }

        public int NumberOfPages { get; set; }

        public string BlobStorageAccountName { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
        public Dictionary<string, string> MetadataDefaultDocument { get; set; }

        public List<int> PlaceholderFileTypes { get; set; }
        public List<int> SourceAndZipFileTypes { get; set; }

        /*Skeleton Section*/
        public bool IsSkeletonSectionEnabled { get; set; }

        /*Preliminary Section*/
        public bool IsPreliminarySectionEnabled { get; set; }
        public string PreliminaryPageNumberPrefix { get; set; }
        public int PageNumberResetFromSection { get; set; }

        /*Feature*/
        public bool IsBundleSearchEnabled { get; set; }
        public bool IsUsingContentEmbeddingOnUpload { get; set; }
        public bool IsSmartMergeEnabled { get; set; }

        public string GenerateRules { get; set; }
    }
}
