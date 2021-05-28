// using System.ComponentModel.DataAnnotations;
// using SwaggerService.Core.Models.Shared;

// namespace SwaggerService.Core.Models.Features
// {
//     /// <summary>
//     /// FeatureCreateRequest
//     /// </summary>
//     public class FeatureCreateRequest : RequestBase
//     {
//         #region Properties

//         /// <summary>
//         /// ExternalId
//         /// </summary>
//         /// <value></value>
//         [Required]
//         [MaxLength(200)]
//         public string ExternalId { get; set; }

//         /// <summary>
//         /// ProductId
//         /// </summary>
//         /// <value></value>
//         [Required]
//         [Range(1, int.MaxValue)]
//         public int? ProductId { get; set; }

//         #endregion
//     }
// }