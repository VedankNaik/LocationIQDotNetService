using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SwaggerService.Core.Models.V2.Nearest
{
    /// <summary>
    /// Nearest
    /// </summary>
    public class NearestRequest
    {
        /// <summary>
        /// Client URL
        /// </summary>   
        [Required]
        public readonly string clientUrl = "https://eu1.locationiq.com/";

        /// <summary>
        /// Request 
        /// </summary>
        [Required]
        public readonly string request = "v1/nearest/driving";

        /// <summary>
        /// input coordinates 
        /// </summary>
        /// <remark>String of format {longitude},{latitude}</remark>
        [Required]
        [DefaultValue("-0.16102,51.523854")]
        public string coordinates { get; set; }

        /// <summary>
        /// bearings 
        /// </summary>
        /// <remark>Limits the search in degrees towards north in clockwise direction</remark>
        [DefaultValue("10,20")]
        public string bearings { get; set; }

        /// <summary>
        /// radiuses 
        /// </summary>
        /// <remark>Limits the search to given radius in meters</remark>
        [DefaultValue("1000")]
        public string radiuses { get; set; }

        /// <summary>
        /// generateHints 
        /// </summary>
        /// <remark>Adds a Hint to the response which can be used in subsequent requests</remark>
        [DefaultValue("true")]
        public bool generateHints { get; set; }

        /// <summary>
        /// Number 
        /// </summary>
        /// <remark>Limits the search to given radius in meters</remark>
        [DefaultValue(1)]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than or equal to 1")]
        public int number { get; set; }

        /// <summary>
        /// Response format
        /// </summary>
        /// <remark>Response format</remark>
        public readonly string format = "json";
    }
}