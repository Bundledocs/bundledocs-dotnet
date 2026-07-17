namespace Bundledocs.Api.Wrapper.Test
{
    using Bundledocs.Api.Wrapper.Models;
    using Bundledocs.Api.Wrapper.Providers;
    using System.Threading.Tasks;
    using Xunit;

    public class BundledocsApiUsers_Fact : ApiRequestBase_Facts
    {
        [Fact(DisplayName = nameof(Returns_ApiResponseCustomer_For_ValidAccessToken_Using_Me_EndPoint))]
        public async Task Returns_ApiResponseCustomer_For_ValidAccessToken_Using_Me_EndPoint()
        {
            //Arrange
            BundledocsApiUsers userApi = new BundledocsApiUsers(_bundledocsApiGetRequestProvider);

            //Act
            BundledocsApiResponseUser apiResponseCustomer = await userApi.Me();

            //Assert                
            Assert.NotNull(apiResponseCustomer);
        }

        [Fact(DisplayName = nameof(Returns_ApiResponseCustomer_For_ValidAccessToken_Using_MeLazy_EndPoint))]
        public async Task Returns_ApiResponseCustomer_For_ValidAccessToken_Using_MeLazy_EndPoint()
        {
            //Arrange
            BundledocsApiUsers userApi = new BundledocsApiUsers(_bundledocsApiGetRequestProvider);

            //Act
            BundledocsApiResponseUser apiResponseCustomer = await userApi.MeLazy();

            //Assert                
            Assert.NotNull(apiResponseCustomer);
        }
    }
}
