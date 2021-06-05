using System.Collections.Generic;
using SwaggerService.Core.Models.Service;

namespace SwaggerService.Core.Interfaces.Infrastructure.Repositories.V1
{
    /// <summary>
    /// IServiceRepositoy interface
    /// </summary>
    public interface IServiceRepository
    {
        #region Methods

        /// <summary>
        /// GetServices
        /// </summary>
        ///
        /// <returns></returns>
        IEnumerable<ServiceResponse> GetServices();        
        
        #endregion
        
    }
}