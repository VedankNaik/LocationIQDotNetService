using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SwaggerService.Core.Models.Features;
using SwaggerService.Core.Models.Shared;
using SwaggerService.Web.Models.Shared;

namespace SwaggerService.Web.Models.Features
{
    /// <summary>
    /// FeatureUpdateRequestBody
    /// </summary>
    public class FeatureUpdateRequestDto
    {
        #region Properties

        /// <summary>
        /// Attributes
        /// </summary>
        /// <value></value>
        [Required]
        [MinLength(1)]
        public IEnumerable<AttributeDto> Attributes { get; set; }


        #endregion
    }
}