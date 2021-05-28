using Microsoft.Extensions.Configuration;
using IAZI.Common.Test.Integration.Shared;
using IAZI.Common.Core.Infrastructure.Interfaces.Data.Repositories.Dapper;
using IAZI.Common.Infrastructure.Data.Repositories.Dapper;
using System;
using System.Threading.Tasks;
using SwaggerService.Core.Models.Features;
using SwaggerService.Core.Interfaces.Services.Features;
using SwaggerService.Infrastructure.Repositories.Features;
using SwaggerService.Core.Services.Features;
using System.Linq;
using SwaggerService.Web;
using Microsoft.Extensions.Options;
using IAZI.Common.Core.Models.Web.Options;
using SwaggerService.Core.Models.Options;

namespace SwaggerService.Integration.Test.Shared
{
    public class TestWebApplicationFactory : TestWebApplicationFactoryBase<Startup>, IDisposable
    {
        #region Properties

        protected override string Environment
        {
            get
            {
                return "Testing";
            }
        }

        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IFeatureService featureService;
        private int requestUserId = 0;
        private int requestCustomerId = 0;   
        public int testFeatureId = 0;
        public int testProductId = 0;
        public int testCustomerId = 0;
        public int testEmployeeId = 0;
        public  readonly string TestFeatureExternalId = "IntegrationTestFeatureControllers";
       
        #endregion

        #region Constructor  
      
        public TestWebApplicationFactory()
        {
            var serviceConfiguration = Services.GetService(typeof(IOptions<CustomServiceOptions<MyOptions>>)) as IOptions<CustomServiceOptions<MyOptions>>;
            var connectionString = serviceConfiguration.Value.Data.GetDbConnectionString();
            UnitOfWork = new UnitOfWork(connectionString);
          
            var featureRepository = new FeatureRepository(UnitOfWork);
            featureService = new FeatureService(serviceConfiguration, featureRepository);

            var x = CleanupEntities().Result;
            x = CreateEntities().Result;
        }

        #endregion

        #region Public methods    

        public new void Dispose()
        {
            base.Dispose();
            var x = CleanupEntities().Result;
        }

        private async Task<int> CreateEntities()
        {          
            //Create Feature
            testFeatureId = await CreateFeature();
          
            return 0;
        }

        private Task<int> CleanupEntities()
        {
            //Delete Product
           /*  var res = await DeleteProduct();
            //Delete Customer
            res = await DeleteCustomer(); */

            return Task.FromResult(0);
        }
              
        private async Task<int> CreateFeature()
        {
            var res = await featureService.CreateFeature(new FeatureCreateRequest
            {
                RequestCustomerId = testCustomerId,
                RequestUserId = testEmployeeId,
                ExternalId = TestFeatureExternalId,
                ProductId = testProductId
            });
            return res.FeatureId;
        }
        protected async Task<int> DeleteFeature(int productId)
        {
            var responseGetCheck = await featureService.GetFeatures(new FeatureGetRequest
            {
                RequestCustomerId = requestCustomerId,
                RequestUserId = requestUserId,
                ProductId = productId
            });

            var existingFeature = responseGetCheck.FirstOrDefault(r => r.FeatureExternalId.Equals(TestFeatureExternalId, StringComparison.InvariantCultureIgnoreCase));
            if (existingFeature != null)
            {
                var responseExistingDelete = await featureService.DeleteFeature(new FeatureDeleteRequest
                {
                    RequestCustomerId = requestCustomerId,
                    RequestUserId = requestUserId,
                    FeatureId = existingFeature.FeatureId,
                    Archive = false
                });
                return existingFeature.FeatureId;
            }
            return 0;
        }
       
        #endregion

        #region Protected methods


        #endregion
    }
}