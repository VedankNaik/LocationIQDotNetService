// using System.ComponentModel;
// using System.Text.Json.Serialization;
// using SwaggerService.Core.Models.Shared;

// namespace SwaggerService.Core.Models.Features
// {
//     /// <summary>
//     /// FeatureDeleteRequest
//     /// </summary>
//     public class FeatureDeleteRequest : RequestBase
//     {
//         #region Properties
        
//         /// <summary>
//         /// FeatureId, will be passed via route
//         /// </summary>
//         /// <value></value>
//         [JsonIgnore]                
//         public int FeatureId { get; set; }

//         /// <summary>
//         /// Flag to indicate if the feature should be archived or really deleted
//         /// </summary>
//         /// <value></value>
//         [DefaultValue(true)]
//         public bool Archive { get; set; } = true;
        
//         #endregion       
//     }
// }