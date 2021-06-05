using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SwaggerService.Core.Models.Shared;

namespace SwaggerService.Core.Models.V2.ReverseGeocode
{
    /// <summary>
    /// ReverseGeocodeRequest
    /// </summary>
    public class ReverseGeocodeRequest
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
        public readonly string request = "v1/reverse.php";

        /// <summary>
        /// Latitide
        /// </summary>
        /// <remark>Latitude of point</remark>
        [Required]
        [DefaultValue(47.3769)]
        [Range(-90, 90, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [JsonPropertyName("Latitude")]
        public decimal lat { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        /// <remark>Longitude of point</remark>
        [Required]
        [DefaultValue(8.5417)]
        [Range(-180, 180, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [JsonPropertyName("Longitude")]
        public decimal lon { get; set; }

        /// <summary>
        /// Zoom
        /// </summary>
        /// <remark>Level of detail required where 0 is country and 18 is house/building</remark>
        [Required]
        [DefaultValue(18)]
        // [Range(0, 18, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int zoom { get; set; }

        /// <summary>
        /// Normalize city
        /// </summary>
        /// <remark>For responses with no city value in the address section, the next available element from the address section will be normalized to city</remark>
        [DefaultValue(true)]
        public bool normalizecity { get; set; }

        /// <summary>
        /// Address details
        /// </summary>
        /// <remark>Include a breakdown of the address into elements</remark>
        [DefaultValue(true)]
        public bool addressdetails { get; set; }

        /// <summary>
        /// Accept Language
        /// </summary>
        /// <remark>Preferred language order for showing search results</remark>
        [DefaultValue("en")]
        public string acceptLanguage { get; set; }

        /// <summary>
        /// Name details
        /// </summary>
        /// <remark>Include a list of alternative names in the results</remark>
        [DefaultValue(true)]
        public bool namedetails { get; set; }

        /// <summary>
        /// extratags
        /// </summary>
        /// <remark>Include additional information in the result if available</remark>
        [DefaultValue(true)]
        public bool extratags { get; set; }

        /// <summary>
        /// statecode
        /// </summary>
        /// <remark>Adds state code when available</remark>
        [DefaultValue(true)]
        public bool statecode { get; set; }

        /// <summary>
        /// showdistance
        /// </summary>
        /// <remark>Returns the straight line distance (meters) between the input location and the result's location</remark>
        [DefaultValue(true)]
        public bool showdistance { get; set; }

        /// <summary>
        /// postaladdress
        /// </summary>
        /// <remark> Returns address inside the postaladdress key</remark>
        [DefaultValue(true)]
        public bool postaladdress { get; set; }

        /// <summary>
        /// Response format
        /// </summary>
        /// <remark>Response format</remark>
        public readonly string format = "json";
    }
}