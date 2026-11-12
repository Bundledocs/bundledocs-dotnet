namespace Bundledocs.Api.Wrapper.Models
{
    public class BundleAnnotationExclusion : BundledocsEntity
    {
        public string UserEmail { get; set; }

        public bool IsRedactionsExcluded { get; set; }
        public bool IsHighlightsExcluded { get; set; }
        public bool IsNotesExcluded { get; set; }
        public bool IsLabelsExcluded { get; set; }
    }
}
