using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace SwaggerService.Core.Models.V2.ForwardGeocode
{
    /// <summary>
    /// ForwardGeocodeRequest
    /// </summary>
    public class ForwardGeocodeRequest
    {
        /// <summary>
        /// Client URL
        /// </summary>   
        [Required]
        // [DefaultValue("https://eu1.locationiq.com/")]
        public readonly string clientUrl = "https://eu1.locationiq.com/";

        /// <summary>
        /// Request 
        /// </summary>
        [Required]
        // [DefaultValue("v1/search.php")]
        public readonly string request = "v1/search.php";

        /// <summary>
        /// Query string
        /// </summary>
        /// <remark>Address to be searched</remark>
        [Required]
        [JsonPropertyName("Query")]
        public string q { get; set; }

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
        /// View box
        /// </summary>
        /// <remark>The preferred area to find search results</remark>
        public string viewbox { get; set; }

        /// <summary>
        /// Bounded
        /// </summary>
        /// <remark>Restrict the results to only items contained with the viewbox</remark>
        [DefaultValue(false)]
        public bool bounded { get; set; }

        /// <summary>
        /// Limit
        /// </summary>
        /// <remark>Limit the number of returned results</remark>
        [DefaultValue(10)]
        // [Range(0, 50, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int limit { get; set; }

        /// <summary>
        /// Accept Language
        /// </summary>
        /// <remark>Preferred language order for showing search results</remark>
        [DefaultValue("en")]
        public string acceptLanguage { get; set; }

        /// <summary>
        /// Country codes
        /// </summary>
        /// <remark>Limit search to a list of countries</remark>
        public string countrycodes { get; set; }

        /// <summary>countrycodes
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
        /// matchquality
        /// </summary>
        /// <remark>Returns additional information about quality of the result in a matchquality object</remark>
        [DefaultValue(true)]
        public bool matchquality { get; set; }

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