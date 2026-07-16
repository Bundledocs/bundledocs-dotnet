namespace Bundledocs.Api.Wrapper.Models
{
    using System;

    public class BundledocsApiResponseBrief : BundledocsApiResponseBase
    {      
        public string Code { get; set; }
        public string Title { get; set; }       

        /*Display Date*/
        public DateTime LastAccessedTimeStamp { get; set; }  
    }
}
