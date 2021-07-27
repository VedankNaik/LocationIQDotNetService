

using System.ComponentModel.DataAnnotations;

namespace SwaggerService.Core.Models.V3.DBConnection
{
    /// <summary>
    /// DBConnectionRequest
    /// </summary>
    public class DBConnectionRequest
    {
        /// <summary>
        /// Server Name
        /// </summary>   
        [Required]
        public string Server { get; set; }

        /// <summary>
        /// Database Name
        /// </summary>   
        [Required]
        public string Database { get; set; }

        /// <summary>
        /// User Name
        /// </summary>   
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary> 
        [DataType(DataType.Password)]    
        [Required]
        public string Password { get; set; }

    }
}