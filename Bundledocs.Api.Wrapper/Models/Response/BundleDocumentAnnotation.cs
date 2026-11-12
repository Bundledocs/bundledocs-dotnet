namespace Bundledocs.Api.Wrapper.Models
{
    using System.Collections.Generic;

    public class BundleDocumentAnnotation : BundledocsEntity
    {
        public int AnnotationType { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public int ContentType { get; set; }

        public string UserRowKey { get; set; }

        public bool IsPrivate { get; set; }
        public bool IsIndicative { get; set; }
        public int PageNumber { get; set; }
        public string PageId { get; set; }

        public string CreatedBy { get; set; }

        public string XRef { get; set; }

        public List<VisibleTo> VisibleTos { get; set; }

        public BundleDocumentAnnotationAutomation Automation { get; set; }

        public string DocumentReferenceRowKey { get; set; }
        public int DocumentReferencePageNumber { get; set; }
        public string DocumentReferenceHyperlink { get; set; }
        public string DocumentReferenceBorderColor { get; set; }
        public string CommentReferenceRowKey { get; set; }
        public string DocumentReferenceAnnotationRowKey { get; set; }

        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
        public double Opacity { get; set; }
        public string FontSize { get; set; }

        public string DocumentStampRowKey { get; set; }

        public bool IsRedact { get; set; }
        public string FontColor { get; set; }
        public string FontFamily { get; set; }
    }
}
