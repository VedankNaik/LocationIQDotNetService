using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SwaggerService.Core.Models.V2.Balance
{

    public class BalanceResponse
    {
        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Balance Object
        /// </summary>
        public BalanceObject balance { get; set; }
        
    }

    public class BalanceObject
    {   
        /// <summary>
        /// Requests remaining for the day
        /// </summary>
        public int day { get; set; }

        /// <summary>
        /// Bonus requests for the day
        /// </summary>
        public int bonus { get; set; }    
    }

}