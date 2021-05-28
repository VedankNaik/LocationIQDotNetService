// using System;
// using System.Linq;
// using System.Threading.Tasks;
// using AutoMapper;
// using IAZI.Common.Core.Models.Resources;
// using IAZI.Common.Core.Models.Web.Options;
// using SwaggerService.Core.Interfaces.Services.Features;
// using SwaggerService.Core.Models.Features;
// using SwaggerService.Core.Models.Options;
// using SwaggerService.Core.Models.Shared;
// using Microsoft.Extensions.Localization;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Options;

// namespace SwaggerService.Web.Controllers.Shared
// {
//     /// <summary>
//     /// Default controller logic for Features
//     /// </summary>
//     public abstract class FeatureControllerBase : ServiceControllerBase
//     {
//         #region Properties
                
//         /// <summary>
//         /// Feature service
//         /// </summary>
//         protected readonly IFeatureService FeatureService;

//         /// <summary>
//         /// Automapper interface
//         /// </summary>
//         protected readonly IMapper Mapper;
            
//         #endregion

//         #region Constructor
               
//         /// <summary>
//         /// Constructor
//         /// </summary>
//         /// <param name="featureService"></param>
//         /// <param name="serviceOptions"></param>
//         /// <param name="logger"></param>
//         /// <param name="localizer"></param>
//         /// <param name="mapper"></param>
//         /// <returns></returns>
//         public FeatureControllerBase(IFeatureService featureService,
//                                  IOptions<CustomServiceOptions<MyOptions>> serviceOptions,
//                                  ILogger<FeatureControllerBase> logger,
//                                  IStringLocalizer<DefaultResource> localizer,
//                                  IMapper mapper) : base(serviceOptions, logger, localizer)
//         {            
//             if (serviceOptions is null)
//             {
//                 throw new ArgumentNullException(nameof(serviceOptions));
//             }

//             if (logger is null)
//             {
//                 throw new ArgumentNullException(nameof(logger));
//             }

//             if (localizer is null)
//             {
//                 throw new ArgumentNullException(nameof(localizer));
//             }
            
//             FeatureService = featureService ?? throw new ArgumentNullException(nameof(featureService));
//             Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
//         }

            
//         #endregion

//         #region Protected methods

//         /// <summary>
//         /// Checks the DB if a feature is available for a given id
//         /// </summary>
//         /// <param name="featureId"></param>
//         /// <param name="requestBase"></param>
//         /// <returns></returns>
//         protected async Task<bool> FeatureExistsById<T>(int featureId,T requestBase) where T : RequestBase
//         {
//             var response = await FeatureService.GetFeatures(new FeatureGetRequest
//             {
//                 FeatureId = featureId,
//                 Culture = requestBase.Culture,
//                 RequestCustomerId = requestBase.RequestCustomerId,
//                 RequestUserId = requestBase.RequestUserId
//             });
//             return response != null && response.Count() == 1;
//         } 
//         #endregion
//     }
// }