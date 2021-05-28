using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SwaggerService.Core.Models.Shared;

namespace SwaggerService.Core.Models.Service
{
    /// <summary>
    /// FeatureCreateRequest
    /// </summary>
    public class ServiceRequest
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // public DateTime CreateDate { get; set; }
        // public DateTime UpdateDate { get; set; }
        public string CreateEmployee { get; set; }
        public string UpdateEmployee { get; set; }
    }
}