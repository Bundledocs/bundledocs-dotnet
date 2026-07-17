namespace Bundledocs.Api.Wrapper.Models
{
    using System.Collections.Generic;

    public class BundledocsApiResponseGroupMember : BundledocsApiResponseBase
    {
        public string Role { get; set; }     
        public string Email { get; set; } 

        /// <summary>
        /// Gets or sets the shared briefs.
        /// </summary>
        /// <value>
        /// The shared briefs.
        /// </value>
        public List<BundledocsApiResponseBrief> BriefsShared { get; set; }        
    }
}
