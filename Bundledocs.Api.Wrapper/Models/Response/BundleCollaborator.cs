namespace Bundledocs.Api.Wrapper.Models
{
    using System;

    public class BundleCollaborator : BundledocsEntity
    {
        public int AccessLevel { get; set; }
        public int ActivationStatus { get; set; }

        public DateTime RestrictionDateStart { get; set; }
        public DateTime RestrictionDateEnd { get; set; }
        public int RestrictionType { get; set; }

        public string Email { get; set; }
    }
}
