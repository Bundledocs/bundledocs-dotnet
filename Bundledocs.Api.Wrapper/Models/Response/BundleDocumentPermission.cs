namespace Bundledocs.Api.Wrapper.Models
{
    using System.Collections.Generic;

    public class BundleDocumentPermission : BundledocsEntity
    {
        public int ResourceRole { get; set; }
        public int? ResourceBriefGroupRole { get; set; }

        public string ResourceRowKey { get; set; }
        public string Name { get; set; }

        public int DocumentsPermissionTreeLevel { get; set; }

        public List<string> UserPermissionRoleRowKeys { get; set; }

        public List<int> DocumentsPermission { get; set; }
        public List<int> InterfaceSettings { get; set; }
    }
}
