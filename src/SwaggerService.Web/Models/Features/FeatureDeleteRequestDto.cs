using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SwaggerService.Core.Models.Features;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerService.Web.Models.Features
{
    /// <summary>
    /// FeatureDeleteRequestBody
    /// </summary>
    public class FeatureDeleteRequestDto
    {
        /// <summary>
        /// Flag to indicate if the feature should be archived or really deleted
        /// </summary>
        /// <value></value>
        [DefaultValue(true)]
        [FromQuery(Name="archive")]
        public bool Archive { get; set; } = true;
    }
}