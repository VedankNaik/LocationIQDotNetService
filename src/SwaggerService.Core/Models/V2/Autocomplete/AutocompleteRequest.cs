using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SwaggerService.Core.Models.Shared;

namespace SwaggerService.Core.Models.V2.Autocomplete
{
    /// <summary>
    /// AutocompleteRequest
    /// </summary>
    public class AutocompleteRequest
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
        public readonly string request = "v1/autocomplete.php";

        /// <summary>
        /// Query string
        /// </summary>
        /// <remark>Address to be searched</remark>
        [Required]
        [JsonPropertyName("Query")]
        [StringLength(50, ErrorMessage = "Query can have max length of 50")]
        public string q { get; set; }

        /// <summary>
        /// Limit
        /// </summary>
        /// <remark>Limit the number of returned results</remark>
        [DefaultValue(10)]
        // [Range(1, 20, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int limit { get; set; }

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
        /// Country codes
        /// </summary>
        /// <remark>Limit search to a list of countries</remark>
        public string countrycodes { get; set; }

        /// <summary>
        /// Tag
        /// </summary>
        /// <remark>Restricts results to specific types of elements</remark>
        public string tag { get; set; }

        /// <summary>
        /// Response format
        /// </summary>
        /// <remark>Response format</remark>
        public readonly string format = "json";
    }
}