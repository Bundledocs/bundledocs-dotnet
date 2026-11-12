namespace Bundledocs.Api.Wrapper.Models
{
    using System.Collections.Generic;

    public class BundleDocumentAnnotationAutomation
    {
        public int TargetOption { get; set; }
        public List<string> TargetRowKeys { get; set; }

        public int PagesOption { get; set; }
        public List<int> TargetPages { get; set; }

        public int PositionOption { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
    }
}
