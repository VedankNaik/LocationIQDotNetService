// using System.ComponentModel.DataAnnotations;
// using System.Text.Json.Serialization;
// using SwaggerService.Core.Models.Shared;

// namespace SwaggerService.Core.Models.Features
// {
//     /// <summary>
//     /// input class for FeatureListGet
//     /// </summary>
//     public class FeatureGetRequest : RequestBase
//     {
//         #region Properties   

//          /// <summary>
//         /// FeatureId
//         /// </summary>
//         /// <value></value>
//         [JsonIgnore]
//         [Range(1, int.MaxValue)]
//         public int? FeatureId { get; set; }   

//         /// <summary>
//         /// ProductId
//         /// </summary>
//         /// <value></value>
//         [JsonIgnore]
//         [Range(1, int.MaxValue)]
//         public int? ProductId { get; set; }         
            
//         #endregion        
//     }
// }