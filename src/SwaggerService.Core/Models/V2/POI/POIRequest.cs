using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SwaggerService.Core.Models.V2.POI
{
    /// <summary>
    /// POI
    /// </summary>
    public class POIRequest
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
        public readonly string request = "v1/nearby.php";

        /// <summary>
        /// Latitide
        /// </summary>
        /// <remark>Latitude of point</remark>
        [Required]
        [DefaultValue(46.9440)]
        [Range(-90, 90, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [JsonPropertyName("Latitude")]
        public decimal lat { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        /// <remark>Longitude of point</remark>
        [Required]
        [DefaultValue(7.4493)]
        [Range(-180, 180, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [JsonPropertyName("Longitude")]
        public decimal lon { get; set; }

        /// <summary>
        /// radius
        /// </summary>
        /// <remark>Limits the search to given radius in meters</remark>
        [DefaultValue(100)]
        [Range(0, 30000, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int radius { get; set; }

        /// <summary>
        /// tag 
        /// </summary>
        /// <remark>Adds a Hint to the response which can be used in subsequent requests</remark>
        [DefaultValue("all")]
        public string tag { get; set; }

        /// <summary>
        /// limit 
        /// </summary>
        /// <remark>Number of results to return</remark>
        [DefaultValue(10)]
        [Range(0, 50, ErrorMessage = "Max value is 50")]
        public int limit { get; set; }

        /// <summary>
        /// Response format
        /// </summary>
        /// <remark>Response format</remark>
        public readonly string format = "json";
    }
}