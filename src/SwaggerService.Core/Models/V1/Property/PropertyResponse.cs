using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SwaggerService.Core.Models.V1.Property
{
    /// <summary>
    /// PropertyResponse
    /// </summary>
    public class PropertyResponse
    {
        /// <summary>
        /// Property address
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// Property owner name
        /// </summary>
        public string ownerName { get; set; }
        /// <summary>
        /// Property price
        /// </summary>
        public int price { get; set; }
    }
}