using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SwaggerService.Core.Models.V2.Directions
{
    /// <summary>
    /// Directions
    /// </summary>
    public class DirectionsRequest
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
        public readonly string request = "v1/directions/driving";

        /// <summary>
        /// coordinates 
        /// </summary>
        /// <remark>String of format {longitude},{latitude};{longitude},{latitude}</remark>
        [Required]
        [DefaultValue("-0.16102,51.523854;-0.15797,51.52326;-0.161593,51.522550")]
        public string coordinates { get; set; }

        /// <summary>
        /// bearings 
        /// </summary>
        /// <remark>Limits the search in degrees towards north in clockwise direction</remark>
        [DefaultValue("10,20;40,30;30,9")]
        public string bearings { get; set; }

        /// <summary>
        /// radiuses 
        /// </summary>
        /// <remark>Limits the search to given radius in meters</remark>
        [DefaultValue("500;200;300")]
        public string radiuses { get; set; }

        /// <summary>
        /// generateHints 
        /// </summary>
        /// <remark>Adds a Hint to the response which can be used in subsequent requests</remark>
        [DefaultValue("true")]
        // [RegularExpression("true|false", ErrorMessage = "generateHints can take any one of following values: true, false")]
        public bool generateHints { get; set; }

        /// <summary>
        /// exclude 
        /// </summary>
        /// <remark>Additive list of classes to avoid</remark>
        [DefaultValue("toll")]
        public string exclude { get; set; }

        /// <summary>
        /// alternatives 
        /// </summary>
        /// <remark>Number of alternative routes</remark>
        [DefaultValue(0)]
        [Range(0, int.MaxValue, ErrorMessage = "Value must be greater than or equal to 0")]
        public int alternatives { get; set; }

        /// <summary>
        /// steps 
        /// </summary>
        /// <remark> Returned route steps for each route leg</remark>
        [DefaultValue(true)]
        public bool steps { get; set; }

        /// <summary>
        /// geometries 
        /// </summary>
        /// <remark>Returned route geometry format</remark>
        [DefaultValue("polyline")]
        [RegularExpression("polyline|polyline6|geojson", ErrorMessage = "Geomerty can take any one of following values: polyline, polyline6, geojson")]
        public string geometries { get; set; }

        /// <summary>
        /// overview 
        /// </summary>
        /// <remark>Add overview geometry</remark>
        [DefaultValue("simplified")]
        [RegularExpression("simplified|full|false", ErrorMessage = "Overview can take any one of following values: simplified, full, false")]
        public string overview { get; set; }

        /// <summary>
        /// geometries 
        /// </summary>
        /// <remark>Forces the route to keep going straight</remark>
        [DefaultValue("default")]
        [RegularExpression("default|true|false", ErrorMessage = "Continue straight can take any one of following values: default, true, false")]
        public string continue_straight { get; set; }

        /// <summary>
        /// Response format
        /// </summary>
        /// <remark>Response format</remark>
        public readonly string format = "json";
    }
}