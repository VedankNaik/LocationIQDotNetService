// using System;
// using System.Collections.Generic;
// using IAZI.Common.Core.Interfaces.Models.Auth;
// using IAZI.Common.Core.Models.Resources;
// using IAZI.Common.Core.Models.Web.Options;
// using IAZI.Common.Service.Utils;
// using IAZI.Common.Service.Web.Controllers.Shared;
// using SwaggerService.Core.Models.Options;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Localization;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Options;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;

// namespace SwaggerService.Web.Controllers.Shared
// {
//     ///<summary>
//     /// Base Controller
//     ///</summary>
//     public class BaseController : ApiControllerBase
//     {
//         #region Protected variables

//         ///<summary>RemoteEndpointMessage</summary>
//         protected const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";

//         ///<summary>OwinContext</summary>
//         protected const string OwinContext = "MS_OwinContext";

//         ///<summary>NSClientIPkey</summary>
//         protected const string NSClientIPkey = "NS-Client-IP";

//         ///<summary>RequestClientIPkey</summary>
//         private const string RequestClientIPkey = "Req-Client-IP";

//         ///<summary>ERR_GENERALERROR</summary>
//         protected const string ERR_GENERALERROR = "GENERAL ERROR";

//         ///<summary>ERR_NOTAUTHENTICATED</summary>
//         protected const string ERR_NOTAUTHENTICATED = "NOT AUTHENTICATED";

//         ///<summary>ERR_NOTAUTHORIZED</summary>
//         protected const string ERR_NOTAUTHORIZED = "NOT AUTHORIZED";

//         ///<summary>ERR_NOTLIVE</summary>
//         protected const string ERR_NOTLIVE = "NOT LIVE";

//         ///<summary>ERR_LIVEOVER</summary>
//         protected const string ERR_LIVEOVER = "LIVE OVER QUERY LIMIT";

//         ///<summary>ERR_INVALID_INPUT</summary>
//         protected const string ERR_INVALID_INPUT = "ERROR: INVALID INPUT";

//         ///<summary>ERR_INVALID_AUTH</summary>
//         protected const string ERR_INVALID_AUTH = "User not authenticated";

//         ///<summary>ERR_EMPTY_TOKEN</summary>
//         protected const string ERR_EMPTY_TOKEN = "Token payload is missing ";

//         ///<summary>ERR_MISSING_PERMISSION</summary>
//         protected const string ERR_MISSING_PERMISSION = "User not authorized for current operation";

//         ///<summary>Email</summary>
//         protected string Email = string.Empty;

//         ///<summary>CustomerName</summary>
//         protected string CustomerName = string.Empty;

//         ///<summary>UserId</summary>
//         protected string UserId = string.Empty;

//         ///<summary>CustomerId</summary>
//         protected string CustomerId = string.Empty;

//         ///<summary>PermiCheckList</summary>
//         protected List<string> PermiCheckList = new List<string>();

//         ///<summary>object of type ModelAuth</summary>
//         protected ModelAuth modelAuth = new ModelAuth();
//         #endregion


//         ///<summary>
//         /// Constructor
//         ///</summary>
//         public BaseController(IOptions<CustomServiceOptions<MyOptions>> serviceOptions, ILogger<BaseController> logger,
//                                 IStringLocalizer<DefaultResource> localizer) : base(serviceOptions, logger, localizer)
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
//         }


//         #region Protected Methods

//          // TODO: Should be kept outside Controller and injected via [Authorize], also it should be replaced by IdentityServer logic 
        
//         /// <summary>
//         /// CheckPermissions
//         /// </summary>
//         /// <returns></returns>
//         protected virtual ObjectResult CheckPermissions()
//         {            
//             PermiCheckList.Clear(); 
//             PermiCheckList.Add(Permission.ModeBase);
//             if (!IsAuthorised(out string message))
//             {
//                 return StatusCode(StatusCodes.Status403Forbidden, message);
//             }
//             else
//             {
//                 return null;
//             }
//         }

//         ///<summary>
//         /// Validate claims
//         ///</summary>
//         protected bool IsAuthorised(out string message)
//         {
//             var claims = HttpContext.GetAuthTokenClaimInfo();
//             if (claims != null && claims.AppData != null)
//             {
//                 foreach (var l2 in claims.AppData)
//                 {
//                     var auth = JsonConvert.DeserializeObject<ModelAuth>(l2);
//                     if (auth.AuthAdmin != null)
//                     {
//                         modelAuth = auth;
//                         foreach (string per in PermiCheckList)
//                         {
//                             if (!Convert.ToBoolean(JObject.Parse(l2).SelectToken(per)))
//                             {
//                                 message = ERR_MISSING_PERMISSION;
//                                 return false;
//                             }
//                         }
//                         message = string.Empty;
//                         return true;
//                     }
//                 }
//             }
            
//             message = ERR_MISSING_PERMISSION;
//             return false;
//         }

//         /// <summary>
//         /// return error response and log error
//         /// </summary>
//         /// <param name="ex"></param>
//         /// <param name="value"></param>
//         /// <returns></returns>
//         protected IActionResult ErrorAsync(Exception ex, object value = null)
//         {
//             var messagestr = "";
//             messagestr += Environment.NewLine + ex.Message;
//             if (ex.Source != null) messagestr += Environment.NewLine + ex.Source;
//             if (ex.InnerException != null) messagestr += Environment.NewLine + ex.InnerException;
//             if (ex.StackTrace != null) messagestr += Environment.NewLine + ex.StackTrace;
//             if (value != null)
//             {
//                 var input_value = Newtonsoft.Json.JsonConvert.SerializeObject(value, Formatting.Indented);
//                 if (!string.IsNullOrEmpty(input_value.ToString()))
//                     messagestr += Environment.NewLine + " Input Parameter: " + Environment.NewLine + input_value.ToString();
//             }
//             Logger.LogError(messagestr);
//             return StatusCode(StatusCodes.Status500InternalServerError, ERR_GENERALERROR);
//         }
//         #endregion
//     }

//     #region Auth Classes

//     ///<summary>
//     /// AuthAdmin class
//     ///</summary>
//     public class AuthAdmin : IAuthBase
//     {
//         ///<summary>Prperty:Modebase type:bool</summary>
//         public bool ModeBase { get; set; }
//     }

//     ///<summary>
//     /// Permission class
//     ///</summary>
//     public static class Permission
//     {
//         ///<summary>Prperty:modebase type:string</summary>
//         public static string ModeBase { get { return "authadmin.modebase"; } }

//     }

//     ///<summary>
//     /// ModelAuth class
//     ///</summary>
//     public class ModelAuth
//     {
//         ///<summary>Prperty:AuthAdmin type:AuthAdmin</summary>
//         public AuthAdmin AuthAdmin { get; set; }
//     }
//     #endregion
// }