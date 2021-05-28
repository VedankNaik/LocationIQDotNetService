using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SwaggerService.Core.Models.Shared;

namespace SwaggerService.Core.Models.V1.Property
{
    /// <summary>
    /// PropertyRequest
    /// </summary>
    public class PropertyRequest
    {
        /// <summary>
        /// Property address
        /// </summary>
        [Required]
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