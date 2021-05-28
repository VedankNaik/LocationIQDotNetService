using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SwaggerService.Core.Models.Shared
{
    /// <summary>
    /// Contains the Feature/Role/Product attribute properties
    /// </summary>
    public class Attribute
    {
        #region Properties

        /// <summary>
        /// Key
        /// </summary>
        /// <value></value>
        [Required]
        [MaxLength(100)]
        public string Key { get; set; }

        /// <summary>
        /// Culture
        /// </summary>
        /// <value></value>
        [Required]
        [MaxLength(5)]
        [DefaultValue(DefaultValues.DefaultCulture)]
        public string Culture { get; set; } = DefaultValues.DefaultCulture;

        /// <summary>
        /// Value
        /// </summary>
        /// <value></value>
        public string Value { get; set; }

        /// <summary>
        /// Source Code
        /// </summary>
        /// <value></value>
        [MaxLength(1)]
        public string SourceCode { get; set; }

        /// <summary>
        /// Status Code
        /// </summary>
        /// <value></value>
        [MaxLength(1)]
        public string StatusCode { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        /// <value></value>
        public string Comment { get; set; }
            
        #endregion
    }
}