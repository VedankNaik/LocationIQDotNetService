using System.Collections.Generic;
using System.Threading.Tasks;
using SwaggerService.Core.Models.Features;
using SwaggerService.Core.Models.Service;

namespace SwaggerService.Core.Interfaces.Services.Service
{
    /// <summary>
    /// IServiceHelper
    /// </summary>
    public interface IServiceHelper 
    {
        #region Methods

        /// <summary>
        /// GetFeatures
        /// </summary>
        /// <param name="serviceGetRequest"></param>
        /// <returns></returns>
        IEnumerable<ServiceResponse> GetAllServices();        

        #endregion
                                   
    }
}