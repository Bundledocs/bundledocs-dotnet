namespace Bundledocs.Api.Wrapper.Test
{
    using System;
    using Xunit;

    public class BundledocsApiClient_Facts
    {
        [Fact(DisplayName = nameof(Creates_Client_With_Only_An_Access_Token))]
        public void Creates_Client_With_Only_An_Access_Token()
        {
            using BundledocsApiClient client = new BundledocsApiClient("token");

            Assert.NotNull(client.Users);
            Assert.NotNull(client.Groups);
            Assert.NotNull(client.Bundles);
        }

        [Theory(DisplayName = nameof(Throws_ArgumentException_For_Missing_Access_Token))]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Throws_ArgumentException_For_Missing_Access_Token(string accessToken)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() => new BundledocsApiClient(accessToken));

            Assert.Equal("accessToken", exception.ParamName);
        }
    }
}
