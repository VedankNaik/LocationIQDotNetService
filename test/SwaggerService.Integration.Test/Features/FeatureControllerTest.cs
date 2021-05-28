using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using IAZI.Common.Service.Utils;
using SwaggerService.Core.Models.Features;
using SwaggerService.Integration.Test.Features.Shared;
using SwaggerService.Integration.Test.Shared;
using SwaggerService.Web.Models.Features;
using SwaggerService.Web.Models.Shared;
using Xunit;
using Xunit.Abstractions;

namespace SwaggerService.Integration.Test.Features
{
    /// <summary>
    /// Testing Feature Controller logic
    /// </summary>
    public class FeatureControllerTest : FeatureControllerTestBase
    {
        #region Properties


        #endregion

        #region Constructor

        protected TestWebApplicationFactory Properties;

        /// <summary>
        /// FeatureControllerTest
        /// </summary>
        /// <returns></returns>
        public FeatureControllerTest(ITestOutputHelper outputHelper, TestWebApplicationFactory factory) : base(outputHelper, factory)
        {
            Properties = factory;
        }

        #endregion

        #region Public methods 

        [Theory]
        [InlineData(HttpStatusCode.Forbidden, "/v1/features")]
        [InlineData(HttpStatusCode.OK, "/v1/features?productId={productId}")]
        [InlineData(HttpStatusCode.BadRequest, "/v1/features?productId=0")]
        public async Task SERAUTHADM17_GetFeatures(HttpStatusCode expectedHttpStatusCode, string url)
        {
            // Arrange 
            url = InitIntegrationTestUserAndUrl(expectedHttpStatusCode, url, new Dictionary<string, object>
            {
                {"{productId}", TestProductId}
            });

            // Act            
            var response = await GetHttpClient().GetAsync(url);

            // Assert
            var responseData = await HandleUrlCallResponse<IEnumerable<FeatureGetResponse>>(response, expectedHttpStatusCode);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, "/v1/features/0")]
        [InlineData(HttpStatusCode.OK, "/v1/features/{featureId}")]
        [InlineData(HttpStatusCode.Forbidden, "/v1/features/{featureId}")]
        public async Task SERAUTHADM19_GetFeature(HttpStatusCode expectedHttpStatusCode, string url)
        {
            // Arrange 
            url = InitIntegrationTestUserAndUrl(expectedHttpStatusCode, url, new Dictionary<string, object>
            {
                { "{featureId}", TestFeatureId }
            });

            // Act            
            var response = await GetHttpClient().GetAsync(url);

            // Assert
            var responseData = await HandleUrlCallResponse<FeatureGetResponseDto>(response, expectedHttpStatusCode, 1);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, "/v1/features/0")]
        [InlineData(HttpStatusCode.Forbidden, "/v1/features/{featureId}")]
        [InlineData(HttpStatusCode.NoContent, "/v1/features/{featureId}")]
        public async Task SERAUTHADM6_UpdateFeature_Given_Input(HttpStatusCode expectedHttpStatusCode, string url)
        {
            // Arrange 
            url = InitIntegrationTestUserAndUrl(expectedHttpStatusCode, url, new Dictionary<string, object>
            {
                { "{featureId}", TestFeatureId }
            });

            var updateRequest = new FeatureUpdateRequestDto
            {

                Attributes = new List<AttributeDto>
                {
                    new AttributeDto
                    {
                        Key = "featureName",
                        Culture = "de-CH",
                        Value = "Integration_Test_Name",
                        Comment = "Test Comment",

                    }
                }
            };

            // Act            
            var response = await GetHttpClient().PutAsJsonAsync<FeatureUpdateRequestDto>(url, updateRequest, JsonFacade, JsonOptions);

            // Assert
            var responseData = await HandleUrlCallResponse<FeatureUpdateResponse>(response, expectedHttpStatusCode);

            // TODO: Load data again and check if updates have been applied
        }


        [Fact]
        public async Task SERAUTHADM18_SERAUTHADM24_SERAUTHADM20_CreateUpdateAndDeleteFeature_Given_Input()
        {
            var createdFeatureId = 0;

            //clean up Feature
            await CleanUpFeature(TestFeatureExternalIdFullTest);
            // Create new Feature
            var expectedStatusCreate = HttpStatusCode.Created;
            var urlCreate = InitIntegrationTestUserAndUrl(expectedStatusCreate, "/v1/features");


            var createFeatureRequestBody = new FeatureCreateRequestDto
            {
                ExternalId = TestFeatureExternalIdFullTest,
                ProductId = TestProductId
            };
            var responseCreate = await GetHttpClient().PostAsJsonAsync<FeatureCreateRequestDto>(urlCreate, createFeatureRequestBody, JsonFacade, JsonOptions);
            var responseDataCreate = await HandleUrlCallResponse<FeatureCreateResponseDto>(responseCreate, expectedStatusCreate);
            createdFeatureId = responseDataCreate.FeatureId;

            // Get Feature
            var resGetFeature = await GetFeature(createdFeatureId, HttpStatusCode.OK);
            Assert.NotNull(resGetFeature);

            // update created feature
            var expectedStatusUpdate = HttpStatusCode.NoContent;
            var urlUpdate = InitIntegrationTestUserAndUrl(expectedStatusUpdate, "/v1/features/{featureId}", new Dictionary<string, object>
            {
                { "{featureId}", createdFeatureId }
            });
            var featureNameUpdated = "CRUDFeatureTest";
            var updateRequest = new FeatureUpdateRequestDto
            {
                Attributes = new List<AttributeDto>
                {
                    new AttributeDto
                    {
                        Key = "featureName",
                        Culture = "de-CH",
                        Value = featureNameUpdated,
                        Comment = "Test Comment"
                    }
                }
            };
            var responseUpdate = await GetHttpClient().PutAsJsonAsync<FeatureUpdateRequestDto>(urlUpdate, updateRequest, JsonFacade, JsonOptions);
            var responseDataUpdate = await HandleUrlCallResponse<FeatureUpdateResponseDto>(responseUpdate, expectedStatusUpdate);

            //verify feature got updated
            var res = await GetFeature(createdFeatureId, HttpStatusCode.OK);
            Assert.Equal(res.FeatureName, featureNameUpdated);

            // Delete Feature
            var urlDelete = InitIntegrationTestUserAndUrl(HttpStatusCode.NoContent, "/v1/features/{featureId}?archive={archive}", new Dictionary<string, object>
            {
                { "{featureId}", createdFeatureId },
                { "{archive}", false }
            });
            var responseDelete = await GetHttpClient().DeleteAsync(urlDelete);
            var responseDataDelete = await HandleUrlCallResponse<FeatureDeleteResponseDto>(responseDelete, HttpStatusCode.NoContent);

            // Verify Feature was deleted
            var resGet = await GetFeature(createdFeatureId, HttpStatusCode.NotFound);
            Assert.Null(resGet);
        }
        #endregion
    }
}