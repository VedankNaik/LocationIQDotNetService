// using System;
// using IAZI.Common.Core.Models.Resources;
// using IAZI.Common.Core.Models.Web.Options;
// using SwaggerService.Core.Models.Options;
// using SwaggerService.Core.Models.Shared;
// using SwaggerService.Web.Models.Shared;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.Extensions.Localization;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Options;

// namespace SwaggerService.Web.Controllers.Shared
// {
//     /// <summary>
//     /// Base Controller for Service Controllers
//     /// </summary>
//     [Authorize]
//     public abstract class ServiceControllerBase : BaseController
//     {
//         #region Properties
            
//         #endregion

//         #region Constructor

//         /// <summary>
//         /// Constructor
//         /// </summary>
//         /// <param name="serviceOptions"></param>
//         /// <param name="logger"></param>
//         /// <param name="localizer"></param>
//         /// <returns></returns>
//         public ServiceControllerBase(IOptions<CustomServiceOptions<MyOptions>> serviceOptions, ILogger<BaseController> logger,
//                                 IStringLocalizer<DefaultResource> localizer) : base(serviceOptions, logger, localizer)
//         {
            
//         }

        
            
//         #endregion

//         #region Protected methods

//         /// <summary>
//         /// Applies the common request headers passed to the endpoint to the Domain Model
//         /// </summary>
//         /// <param name="requestHeaderBaseDto"></param>
//         /// <param name="targetDomainModel"></param>
//         /// <typeparam name="T"></typeparam>
//         protected virtual void ApplyRequestBaseHeaders<T>(RequestBaseDto requestHeaderBaseDto, T targetDomainModel) where T: RequestBase
//         {
//             if (requestHeaderBaseDto is null)
//             {
//                 throw new ArgumentNullException(nameof(requestHeaderBaseDto));
//             }

//             if (targetDomainModel is null)
//             {
//                 throw new ArgumentNullException(nameof(targetDomainModel));
//             }
             
//             targetDomainModel.Culture = requestHeaderBaseDto.Culture;
//             targetDomainModel.RequestCustomerId = requestHeaderBaseDto.RequestCustomerId;
//             targetDomainModel.RequestUserId = requestHeaderBaseDto.RequestUserId;
//         }
            
//         #endregion
//     }
// }