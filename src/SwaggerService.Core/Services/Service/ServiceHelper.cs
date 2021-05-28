using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SwaggerService.Core.Interfaces.Infrastructure.Repositories.V1;
using SwaggerService.Core.Interfaces.Services.Service;
using SwaggerService.Core.Models.Features;
using SwaggerService.Core.Models.Service;

namespace SwaggerService.Core.Services.Service
{
    /// <summary>
    /// Implementation of IServiceHelper
    /// </summary>
    public class ServiceHelper : IServiceHelper
    {
        #region Properties

        private readonly IServiceRepository _serviceRepository;
            
        #endregion
        
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="featureRepository"></param>
        public ServiceHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
            // _featureRepository = featureRepository ?? throw new ArgumentNullException(nameof(featureRepository));
        }

       

        #endregion

        #region Public methods

        /// <summary>
        /// GetAllService
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IEnumerable<ServiceResponse> GetAllServices()
        {    
            var response = _serviceRepository.GetServices();
            //ServiceResponse response = new ServiceResponse();
            //response = res;
            return response;
        }

        #endregion
    }
}