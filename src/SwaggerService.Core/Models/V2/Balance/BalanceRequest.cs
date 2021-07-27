using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace SwaggerService.Core.Models.V2.Balance
{
    /// <summary>
    /// BalanceRequest
    /// </summary>
    public class BalanceRequest
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
        public readonly string request = "v1/balance.php";

        /// <summary>
        /// Response format
        /// </summary>
        /// <remark>Response format</remark>
        public readonly string format = "json";
    }
}