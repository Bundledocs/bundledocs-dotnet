namespace Bundledocs.Api.Wrapper.Interfaces
{
    /// <summary>
    /// Defines the public contract for the Bundledocs API wrapper.
    /// </summary>
    public interface IBundledocsApi
    {
        IBundledocsApiUsers Users { get; }

        IBundledocsApiGroups Groups { get; }

        IBundledocsApiBundles Bundles { get; }
    }
}
