namespace Bundledocs.Api.Wrapper.Models
{
    internal class BundledocsApiResponseMessage
    {
        public OAuthApiMessageScope Scope { get; set; }

        public string Message { get; set; }

        public string Description { get; set; }

        public string Id { get; set; }

        public object Data { get; set; }

        public enum OAuthApiMessageScope
        {
            GLOBAL = 0,
            FORM = 1,
            FORM_ITEM = 2,
            LOG = 3
        }
    }
}
