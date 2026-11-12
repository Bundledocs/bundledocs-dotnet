namespace Bundledocs.Api.Wrapper.Models
{
    using System.Collections.Generic;

    public class GroupMember : BundledocsEntity
    {
        public string Role { get; set; }     
        public string Email { get; set; } 

        /// <summary>
        /// Gets or sets the shared bundles.
        /// </summary>
        /// <value>
        /// The shared bundles.
        /// </value>
        public List<Bundle> BriefsShared { get; set; }        
    }
}
