namespace Bundledocs.Api.Wrapper.Models
{
    using System;
    using System.Collections.Generic;

    public class BundleDocument : BundledocsEntity
    {
        public int CustomIndexGroupKey { get; set; }

        public int ZipIndexSource { get; set; }
        public int ZipIndexSourceSection { get; set; }
        public string ZipIndexSourceCode { get; set; }
        public string ZipIndexSourceCodeSection { get; set; }

        public int PageNumberOffset { get; set; }

        public int Status { get; set; }
        public int OcrStatus { get; set; }
        public int OptimizeContentStatus { get; set; }
        public string ActionStatus { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }
        public string BorderColor { get; set; }

        public string PageRange { get; set; }
        public string FileUploadBatch { get; set; }
        public string FileUploadKey { get; set; }
        public string BurstRange { get; set; }

        public bool IsExpanded { get; set; }
        public bool IsContinuation { get; set; }

        public bool IsIncluded { get; set; }
        public bool IsSimpleInsert { get; set; }
        public bool IsStrikeOut { get; set; }
        public bool IsLateInsert { get; set; }

        public bool IsHiddenOnIndexPages { get; set; }

        public bool IsBookmarkDisplayExclusive { get; set; }

        public bool IsUsingSourceFileDimensions { get; set; }

        /*Legacy (always empty in the API)*/
        public string SourceFilePath { get; set; }
        public string PdfFilePath { get; set; }

        public string ParentRowKey { get; set; }

        public string DisplayOrder { get; set; }
        public string DisplayOrderStatic { get; set; }
        public int NumberOfPages { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileExtension { get; set; }

        public string DisplayDate { get; set; }
        public string DisplayDateFormat { get; set; }
        public string DisplayDatePrinted { get; set; }

        public DateTime DateRegenerated { get; set; }

        public string CustomColumnText { get; set; }
        public string XRef { get; set; }
        public string XRefAlt { get; set; }
        public int XRefAltSource { get; set; }

        public string DocumentReferenceRowKey { get; set; }

        /*BatesStamp*/
        public string BatesStamp { get; set; }
        public int BatesStampStart { get; set; }
        public string BatesStampPrefix { get; set; }
        public string BatesStampSuffix { get; set; }
        public int BatesStampLength { get; set; }
        public bool IsBatesStampLocked { get; set; }
        public int BatesStampSequence { get; set; }

        public bool IsSplitPoint { get; set; }

        public int PageSize { get; set; }

        public int StampType { get; set; }
        public List<StampTemplateField> StampTemplateFields { get; set; }

        public List<BundleDocument> Children { get; set; }

        public List<BundleDocumentAnnotation> Annotations { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public List<SystemTag> Tags { get; set; }

        public List<string> SourceFileDataUrlBlocks { get; set; }

        /*Permissions*/
        public List<BundleDocumentPermission> Permission { get; set; }
        public List<BundleDocumentPermission> PermissionApplied { get; set; }
        public List<BundleDocumentPermission> PermissionAll { get; set; }
    }
}
