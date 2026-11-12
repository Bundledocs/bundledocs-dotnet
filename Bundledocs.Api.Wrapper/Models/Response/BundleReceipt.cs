namespace Bundledocs.Api.Wrapper.Models
{
    using System;
    using System.Collections.Generic;

    public class BundleReceipt : BundledocsEntity
    {
        public string Description { get; set; }

        /*Legacy*/
        public string PdfFilePath { get; set; }
        public long PdfFileLength { get; set; }

        public DateTime DateGenerateStart { get; set; }
        public DateTime DateGenerateEnd { get; set; }
        public int NumberOfPages { get; set; }
        public string FileExtension { get; set; }
        public long FileLength { get; set; }

        public bool IsOcr { get; set; }
        public int OcrStatus { get; set; }

        public string GeneratedByEmail { get; set; }
        public string GeneratedByRowKey { get; set; }

        public bool IsSecurityPassword { get; set; }
        public int ActionStatus { get; set; }

        public List<DownloadInvitation> BriefReceiptDownloadInvitations { get; set; }
    }
}
