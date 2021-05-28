using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using IAZI.Common.Core.Infrastructure.Interfaces.Data.Repositories.Dapper;
using IAZI.Common.Core.Models.Auth;
using IAZI.Common.Test.Integration.Models;
using IAZI.Common.Test.Integration.Shared;
using Xunit;
using Xunit.Abstractions;
using IAZI.Common.Infrastructure.Data.Repositories.Dapper;
using System.Net.Http;
using SwaggerService.Web;
using Microsoft.Extensions.Options;
using IAZI.Common.Core.Models.Web.Options;
using SwaggerService.Core.Models.Options;

namespace SwaggerService.Integration.Test.Shared
{
    public abstract class ServiceControllerTestBase : ControllerIntegrationTestBase<Startup>, IClassFixture<TestWebApplicationFactory>
    {
        #region Properties         

        protected IUnitOfWork UnitOfWork;

        protected IOptions<CustomServiceOptions<MyOptions>> ServiceOptions;

        private const string XCultureRequestHeader = "de-CH";
        private readonly int XCustomerIdRequestHeader = 0;
        private readonly int XUserIdRequestHeader = 0;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public ServiceControllerTestBase(ITestOutputHelper outputHelper, TestWebApplicationFactory factory) : base(outputHelper, factory)
        {
            ServiceOptions = Factory.Services.GetService(typeof(IOptions<CustomServiceOptions<MyOptions>>)) as IOptions<CustomServiceOptions<MyOptions>>;
            var connectionString = ServiceOptions.Value.Data.GetDbConnectionString();
            UnitOfWork = new UnitOfWork(connectionString);    
            XCustomerIdRequestHeader = factory.testCustomerId;
            XUserIdRequestHeader = factory.testEmployeeId;      
      
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Dispose method
        /// </summary>
        public override void Dispose()
        {
            // Cleanup after each test
            //var result = CleanUpFeature(TestFeatureExternalId).Result;

            // Cleanup other objects
            if (UnitOfWork != null)
            {
                UnitOfWork.Dispose();
                UnitOfWork = null;
            }

            base.Dispose();
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Set the Integration Test User
        /// </summary>
        /// <param name="expectedHttpStatusCode"></param>
        protected override void ModifyIntegrationTestUser(HttpStatusCode expectedHttpStatusCode)
        {
            if (expectedHttpStatusCode != HttpStatusCode.Forbidden)
            {
                // Create a default system user wtih access to the service
                IntegrationTestUser.UserClaims = new List<Claim>
                {
                    new Claim(IAZIToken.LegacyAppData, "{\"authadmin\":{\"modebase\":true}}"),
                    new Claim(IAZIToken.LegacyUserId, "3360"),
                    new Claim(IAZIToken.LegacyEmail, "ams@iazi.ch"),
                    new Claim(IAZIToken.LegacyCustomerName, "System"),
                    new Claim(IAZIToken.LegacyCustomerId, "62")
                };
            }
            else
            {
                IntegrationTestUser.UserClaims = new List<Claim>
                {
                };
            }
        }     

        /// <summary>
        /// sets headers for each request
        /// </summary>
        /// <param name="allowAutoRedirect"></param>
        /// <returns></returns>
        protected override HttpClient GetHttpClient(bool allowAutoRedirect = true)
        {
            var httpClient = base.GetHttpClient();
            httpClient.DefaultRequestHeaders.Remove("X-Culture");
            httpClient.DefaultRequestHeaders.Remove("X-UserId");
            httpClient.DefaultRequestHeaders.Remove("X-CustomerId");
            httpClient.DefaultRequestHeaders.Add("X-Culture", XCultureRequestHeader);
            httpClient.DefaultRequestHeaders.Add("X-UserId", XUserIdRequestHeader.ToString());
            httpClient.DefaultRequestHeaders.Add("X-CustomerId", XCustomerIdRequestHeader.ToString());

            return httpClient;
        }
        #endregion
    }
}