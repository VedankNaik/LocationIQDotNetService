// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.Text.Json.Serialization;
// using SwaggerService.Core.Models.Shared;

// namespace SwaggerService.Core.Models.Features
// {
//     /// <summary>
//     /// FeatureUpdateRequest
//     /// </summary>
//     public class FeatureUpdateRequest : RequestBase
//     {
//         #region Properties

//         /// <summary>
//         /// FeatureId
//         /// </summary>
//         /// <value></value>
//         [JsonIgnore]
//         public int FeatureId { get; set; }

//         /// <summary>
//         /// Attributes
//         /// </summary>
//         /// <value></value>
//         [Required]
//         [MinLength(1)]
//         public IEnumerable<Attribute> Attributes { get; set; }

//         #endregion
//     }
// }