using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SwaggerService.Core.Models.Shared;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerService.Web.Models.Features
{
    /// <summary>
    /// FeatureGetRequestQuery
    /// </summary>
    public class FeatureGetRequestDto
    {       
        #region Properties
        
        /// <summary>
        /// ProductId
        /// </summary>
        /// <value></value>
        [Required]
        [Range(1, int.MaxValue)]
        [DefaultValue(DefaultValues.DefaultProductId)]
        [FromQuery(Name = "productId")]
        public int? ProductId { get; set; } = DefaultValues.DefaultProductId;  

        #endregion        
    }
}