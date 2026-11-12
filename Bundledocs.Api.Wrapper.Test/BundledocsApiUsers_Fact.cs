namespace Bundledocs.Api.Wrapper.Test
{
    using Bundledocs.Api.Wrapper.Interfaces;
    using Bundledocs.Api.Wrapper.Models;
    using Bundledocs.Api.Wrapper.Providers;
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    /// <summary>
    /// Offline fake: records the requested endpoint and returns a fixed user.
    /// </summary>
    internal sealed class FakeRequestProvider : IBundledocsApiRequestProvider
    {
        // Test e-mails have no top-level domain on purpose: the publishing scan blocks anything that looks like a real e-mail address.
        internal User User { get; } = new User { Email = "user@example" };

        internal List<string> Endpoints { get; } = new List<string>();

        public Task<T> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
        {
            Endpoints.Add(endpoint);
            return Task.FromResult((T)(object)User);
        }

        public Task<T[]> GetListAsync<T>(string endpoint, CancellationToken cancellationToken = default) => throw new NotSupportedException();

        public Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest body = default, CancellationToken cancellationToken = default) => throw new NotSupportedException();
    }

    public class BundledocsApiUsers_Fact
    {
        private readonly FakeRequestProvider _provider = new FakeRequestProvider();

        private readonly IBundledocsApiUsers _users;

        public BundledocsApiUsers_Fact()
        {
            _users = new BundledocsApiUsers(_provider);
        }

        [Fact(DisplayName = nameof(GetMeAsync_Without_Options_Calls_Lazy_Endpoint_And_Returns_User))]
        public async Task GetMeAsync_Without_Options_Calls_Lazy_Endpoint_And_Returns_User()
        {
            User user = await _users.GetMeAsync();

            Assert.Same(_provider.User, user);
            Assert.Equal("/users/me/lazy", Assert.Single(_provider.Endpoints));
        }

        [Theory(DisplayName = nameof(GetMeAsync_Calls_Expected_Endpoint_For_Expand_Values))]
        [InlineData(null, "/users/me/lazy")]
        [InlineData(new string[0], "/users/me/lazy")]
        [InlineData(new[] { "", " ", null }, "/users/me/lazy")]
        [InlineData(new[] { "user.unknown" }, "/users/me/lazy")]
        [InlineData(new[] { "user.subscription" }, "/users/me/lazy")]
        [InlineData(new[] { MeExpand.Bundles }, "/users/me")]
        [InlineData(new[] { "USER.BRIEFS" }, "/users/me")]
        [InlineData(new[] { " user.briefs " }, "/users/me")]
        [InlineData(new[] { MeExpand.Bundles, MeExpand.Bundles }, "/users/me")]
        [InlineData(new[] { "user.subscription", "user.unknown", MeExpand.Bundles }, "/users/me")]
        public async Task GetMeAsync_Calls_Expected_Endpoint_For_Expand_Values(string[] expand, string expectedEndpoint)
        {
            await _users.GetMeAsync(new MeRequestOptions { Expand = expand });

            Assert.Equal(expectedEndpoint, Assert.Single(_provider.Endpoints));
        }
    }

    public class User_Fact
    {
        private const string UserJson = @"{
            ""errors"": [], ""messages"": [],
            ""data"": [{
                ""PartitionKey"": ""pk-1"", ""RowKey"": ""rk-1"",
                ""Timestamp"": ""2026-10-01T10:00:00+00:00"",
                ""Created"": ""2026-01-02T03:04:05"",
                ""LastAccessedTimeStamp"": ""2026-10-19T08:00:00"",
                ""ForeignKey"": ""fk-1"", ""IsDeleted"": true,
                ""Type"": ""STANDARD"", ""Domain"": ""example.com"",
                ""Email"": ""user@example"", ""FirstName"": ""First"", ""LastName"": ""Last"",
                ""SessionIdleTimeout"": 30, ""UserRole"": 2,
                ""BriefZoomLevel"": 100, ""BriefPageSize"": 1,
                ""IsBriefVerifiedBeforeGenerating"": true,
                ""NotificationsLastReadTimeStamp"": ""2026-10-18T00:00:00"",
                ""Metadata"": { ""key"": ""value"" },
                ""PinnedBriefs"": [{ ""PartitionKey"": ""pk-b"", ""RowKey"": ""rk-b"", ""Created"": ""2026-10-10T00:00:00"" }],
                ""SmokeballDomainEndpoint"": 3,
                ""FeatureStatusEdit"": 1,
                ""Briefs"": [{ ""PartitionKey"": ""pk-b"", ""RowKey"": ""rk-b"", ""Code"": ""B1"", ""Title"": ""Bundle 1"" }],
                ""IsAdmin"": false, ""Username"": ""username""
            }]
        }";

        [Fact(DisplayName = nameof(Deserializes_All_User_Fields_Returned_By_Me_Endpoint))]
        public void Deserializes_All_User_Fields_Returned_By_Me_Endpoint()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            User user = JsonSerializer.Deserialize<BundledocsApiResponse<User>>(UserJson, options).Data[0];

            Assert.Equal("rk-1", user.RowKey);
            Assert.Equal(DateTimeOffset.Parse("2026-10-01T10:00:00+00:00"), user.Timestamp);
            Assert.Equal("fk-1", user.ForeignKey);
            Assert.True(user.IsDeleted);
            Assert.Equal("STANDARD", user.Type);
            Assert.Equal("user@example", user.Email);
            Assert.Equal("First", user.FirstName);
            Assert.Equal(30, user.SessionIdleTimeout);
            Assert.Equal(2, user.UserRole);
            Assert.True(user.IsBriefVerifiedBeforeGenerating);
            Assert.Equal(new DateTime(2026, 10, 18), user.NotificationsLastReadTimeStamp);
            Assert.Equal("value", user.Metadata["key"]);
            Assert.Equal("rk-b", Assert.Single(user.PinnedBriefs).RowKey);
            Assert.Equal(3, user.SmokeballDomainEndpoint);
            Assert.Equal(1, user.FeatureStatusEdit);
            Assert.Equal("B1", Assert.Single(user.Briefs).Code);
        }

        private const string BriefJson = @"{
            ""data"": [{
                ""RowKey"": ""rk-1"",
                ""Briefs"": [{
                    ""PartitionKey"": ""pk-b"", ""RowKey"": ""rk-b"", ""ETag"": {},
                    ""LastAccessedTimeStamp"": ""2026-10-19T08:00:00"",
                    ""Code"": ""B1"", ""Title"": ""Bundle 1"", ""PdfFileLength"": 5000000000,
                    ""IsLocked"": true, ""SectionHierarchyLevelDisplay"": 2,
                    ""PlaceholderFileTypes"": [1, 2], ""Metadata"": { ""a"": ""b"" },
                    ""BriefDocuments"": [{
                        ""RowKey"": ""rk-d"", ""Type"": ""DOCUMENT"", ""DisplayDate"": ""2026-10-01"", ""PageSize"": 4,
                        ""StampTemplateFields"": [{ ""Key"": ""k1"" }],
                        ""Tags"": [{ ""Role"": 200, ""Name"": ""#Duplicate"", ""Data"": { ""TargetRowKey"": ""rk-x"" } }],
                        ""Children"": [{ ""RowKey"": ""rk-child"" }],
                        ""Permission"": [{ ""Name"": ""P"", ""ResourceBriefGroupRole"": null, ""DocumentsPermission"": [10, 20], ""InterfaceSettings"": [10] }],
                        ""Annotations"": [{
                            ""RowKey"": ""rk-a"", ""Opacity"": 0.5, ""PageNumber"": 3,
                            ""VisibleTos"": [{ ""RowKey"": ""rk-v"", ""Role"": 1, ""Name"": ""V"", ""ResourceBriefGroupRole"": 2 }],
                            ""Automation"": { ""TargetOption"": 1, ""TargetRowKeys"": [""rk-t""], ""TargetPages"": [1, 2], ""OffsetX"": 1.5 }
                        }]
                    }],
                    ""BriefReceipts"": [{ ""RowKey"": ""rk-r"", ""FileLength"": 10, ""BriefReceiptDownloadInvitations"": [{ ""RowKey"": ""rk-i"", ""Email"": ""x@y"" }] }],
                    ""BriefShares"": [{ ""Email"": ""s@y"" }],
                    ""BriefCollaborators"": [{ ""AccessLevel"": 2, ""Email"": ""c@y"" }],
                    ""BriefVisibleTos"": [{ ""Role"": 3, ""VisibleToRowKey"": ""rk-vt"" }],
                    ""MigrationInvitation"": { ""DestinationUserEmail"": ""m@y"", ""ExpiryDate"": ""2026-12-01T00:00:00"", ""DestinationUserRowKey"": ""rk-m"", ""IsAccepted"": true },
                    ""BriefAnnotationExclusions"": [{ ""UserEmail"": ""e@y"", ""IsNotesExcluded"": true }]
                }]
            }]
        }";

        [Fact(DisplayName = nameof(Deserializes_All_Bundle_Fields_Returned_Inside_Me_Endpoint))]
        public void Deserializes_All_Bundle_Fields_Returned_Inside_Me_Endpoint()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            Bundle bundle = Assert.Single(JsonSerializer.Deserialize<BundledocsApiResponse<User>>(BriefJson, options).Data[0].Briefs);

            Assert.Equal("B1", bundle.Code);
            Assert.Equal(5000000000, bundle.PdfFileLength);
            Assert.True(bundle.IsLocked);
            Assert.Equal(2, bundle.SectionHierarchyLevelDisplay);
            Assert.Equal(new[] { 1, 2 }, bundle.PlaceholderFileTypes);
            Assert.Equal("b", bundle.Metadata["a"]);
            Assert.Equal(new DateTime(2026, 10, 19, 8, 0, 0), bundle.LastAccessedTimeStamp);

            BundleDocument document = Assert.Single(bundle.BriefDocuments);
            Assert.Equal("DOCUMENT", document.Type);
            Assert.Equal(4, document.PageSize);
            Assert.Equal("k1", Assert.Single(document.StampTemplateFields).Key);
            Assert.Equal("#Duplicate", Assert.Single(document.Tags).Name);
            Assert.Equal("rk-child", Assert.Single(document.Children).RowKey);
            Assert.Null(Assert.Single(document.Permission).ResourceBriefGroupRole);
            Assert.Equal(new[] { 10, 20 }, document.Permission[0].DocumentsPermission);

            BundleDocumentAnnotation annotation = Assert.Single(document.Annotations);
            Assert.Equal(0.5, annotation.Opacity);
            Assert.Equal(3, annotation.PageNumber);
            Assert.Equal(2, Assert.Single(annotation.VisibleTos).ResourceBriefGroupRole);
            Assert.Equal(new[] { 1, 2 }, annotation.Automation.TargetPages);
            Assert.Equal(1.5, annotation.Automation.OffsetX);

            Assert.Equal("x@y", Assert.Single(Assert.Single(bundle.BriefReceipts).BriefReceiptDownloadInvitations).Email);
            Assert.Equal("s@y", Assert.Single(bundle.BriefShares).Email);
            Assert.Equal("c@y", Assert.Single(bundle.BriefCollaborators).Email);
            Assert.Equal("rk-vt", Assert.Single(bundle.BriefVisibleTos).VisibleToRowKey);
            Assert.True(bundle.MigrationInvitation.IsAccepted);
            Assert.Equal("rk-m", bundle.MigrationInvitation.DestinationUserRowKey);
            Assert.True(Assert.Single(bundle.BriefAnnotationExclusions).IsNotesExcluded);
        }
    }
}
