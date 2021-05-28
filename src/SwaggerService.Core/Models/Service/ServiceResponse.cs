using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SwaggerService.Core.Models.Service
{
    /// <summary>
    /// ServiceResponse
    /// </summary>
    public class ServiceResponse 
    {
        #region Properties
        
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // public DateTime CreateDate { get; set; }
        // public DateTime UpdateDate { get; set; }
        public string CreateEmployee { get; set; }
        public string UpdateEmployee { get; set; }
    
       
        #endregion        
    }
}