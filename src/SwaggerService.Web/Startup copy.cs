// using System;
// using IAZI.Common.Service.Web.Init;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using IAZI.Common.Core.Infrastructure.Interfaces.Data.Repositories.Dapper;
// using SwaggerService.Core.Services.Features;
// using SwaggerService.Core.Interfaces.Services.Features;
// using SwaggerService.Infrastructure.Repositories.Features;
// using SwaggerService.Core.Interfaces.Infrastructure.Repositories.Features;
// using IAZI.Common.Service.Web.Providers;
// using IAZI.Common.Infrastructure.Data.Repositories.Dapper;
// using SwaggerService.Core.Models.Options;

// namespace SwaggerService.Web
// {
//     /// <summary>
//     /// Startup class for Service
//     /// </summary>
//     public class Startup : ServiceStartup
//     {
//         #region Properties

//         #endregion

//         #region Constructor

//         /// <summary>
//         /// Constructor
//         /// </summary>
//         /// <param name="configuration"></param>
//         /// <param name="env"></param>
//         public Startup(IConfiguration configuration, IWebHostEnvironment env) : base(configuration, env)
//         {
//         }

//         #endregion        

//         #region Protected Methods

//         /// <summary>
//         /// InitIoC
//         /// </summary>
//         /// <param name="services"></param>
//         protected override void InitIoC(IServiceCollection services)
//         {
//             if (services is null)
//             {
//                 throw new ArgumentNullException(nameof(services));
//             }

//             base.InitIoC(services);                                

//             #region IoCFeatures

//             services.AddScoped<IFeatureService, FeatureService>();
//             services.AddScoped<IFeatureRepository, FeatureRepository>();

//             #endregion
//         }

//         protected override void InitOptions(IServiceCollection services)
//         {
//             base.InitOptions(services);
            
//             base.InitCustomOptions<MyOptions>(services, MyOptions.ValidateSettings, (services, options) => { return; }, (services, options) => { return; });
//         }

//         /// <summary>
//         /// 
//         /// </summary>
//         /// <param name="options"></param>
//         protected override void InitLocalizationRequestCultureProviders(RequestLocalizationOptions options)
//         {
//             if (options is null)
//             {
//                 throw new ArgumentNullException(nameof(options));
//             }

//             options.RequestCultureProviders.Clear();
//             options.RequestCultureProviders.Add(new XCultureHeaderRequestCultureProvider());            
//         }

//         #endregion
//     }
// }