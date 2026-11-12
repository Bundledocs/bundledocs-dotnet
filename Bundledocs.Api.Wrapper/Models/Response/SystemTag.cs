namespace Bundledocs.Api.Wrapper.Models
{
    using System.Collections.Generic;

    public class SystemTag
    {
        public int Role { get; set; }
        public string Name { get; set; }
        public Dictionary<string, object> Data { get; set; }
    }
}
