using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using SwaggerService.Core.Interfaces.Infrastructure.Repositories.Features;
using SwaggerService.Core.Interfaces.Services.Features;
using SwaggerService.Core.Models.Features;
using SwaggerService.Core.Services.Features;
using SwaggerService.Infrastructure.Repositories.Features;
using SwaggerService.Integration.Test.Shared;
using SwaggerService.Web.Models.Features;
using Xunit;
using Xunit.Abstractions;

namespace SwaggerService.Integration.Test.Features.Shared
{
    public abstract class FeatureControllerTestBase : ServiceControllerTestBase, IClassFixture<TestWebApplicationFactory>
    {
        #region Properties  

        protected const string TestFeatureExternalIdFullTest = "IntegrationFeatureFullTest";

        // TODO: Remove test id
        protected readonly int TestCustomerId = 0;
        protected readonly int TestEmployeeId = 0;
        protected readonly int TestFeatureId = 0;
        protected readonly int TestProductId = 0;
        protected readonly IFeatureService FeatureService;

        protected readonly IFeatureRepository FeatureRepository;


        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public FeatureControllerTestBase(ITestOutputHelper outputHelper, TestWebApplicationFactory factory) : base(outputHelper, factory)
        {
            FeatureRepository = new FeatureRepository(UnitOfWork);
            FeatureService = new FeatureService(ServiceOptions, FeatureRepository);

            TestFeatureId = factory.testFeatureId;
            TestProductId = factory.testProductId;
            TestCustomerId = factory.testCustomerId;
            TestEmployeeId = factory.testEmployeeId;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Dispose method
        /// </summary>
        public override void Dispose()
        {
            var res = CleanUpFeature(TestFeatureExternalIdFullTest).Result;
            base.Dispose();
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Feature cleanup
        /// </summary>
        /// <param name="externalId"></param>
        /// <returns></returns>
        protected async Task<int> CleanUpFeature(string externalId)
        {
            var responseGetCheck = await FeatureService.GetFeatures(new FeatureGetRequest
            {
                RequestCustomerId = TestCustomerId,
                RequestUserId = TestEmployeeId,
                ProductId = TestProductId
            });
            Assert.NotNull(responseGetCheck);

            var existingFeature = responseGetCheck.FirstOrDefault(r => r.FeatureExternalId.Equals(externalId, StringComparison.InvariantCultureIgnoreCase));
            if (existingFeature != null)
            {
                var responseExistingDelete = await FeatureService.DeleteFeature(new FeatureDeleteRequest
                {
                    RequestCustomerId = TestCustomerId,
                    RequestUserId = TestEmployeeId,
                    FeatureId = existingFeature.FeatureId,
                    Archive = false
                });
                Assert.NotNull(responseExistingDelete);
                return existingFeature.FeatureId;
            }

            responseGetCheck = await FeatureService.GetFeatures(new FeatureGetRequest
            {
                RequestCustomerId = TestCustomerId,
                RequestUserId = TestEmployeeId,
                ProductId = TestProductId
            });
            Assert.NotNull(responseGetCheck);
            existingFeature = responseGetCheck.FirstOrDefault(r => r.FeatureExternalId.Equals(externalId, StringComparison.InvariantCultureIgnoreCase));
            Assert.Null(existingFeature);

            return 0;
        }

        protected async Task<FeatureGetResponseDto> GetFeature(int featureId, HttpStatusCode expectedHttpStatusCode)
        {
            var urlGet = InitIntegrationTestUserAndUrl(expectedHttpStatusCode, "/v1/features/{featureId}", new Dictionary<string, object>
            {
                { "{featureId}", featureId }
            });

            var responseGet = await GetHttpClient().GetAsync(urlGet);
            var responseDataGet = await HandleUrlCallResponse<FeatureGetResponseDto>(responseGet, expectedHttpStatusCode);
            return responseDataGet;
        }
        #endregion
    }
}