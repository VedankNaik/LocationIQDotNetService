using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SwaggerService.Core.Interfaces.Infrastructure.Repositories.V1;
using SwaggerService.Core.Interfaces.Services.Service;
using SwaggerService.Core.Interfaces.Services.V1.Property;
using SwaggerService.Core.Models.Features;
using SwaggerService.Core.Models.Service;
using SwaggerService.Core.Models.V1.Property;

namespace SwaggerService.Core.Services.V1.Property
{
    /// <summary>
    /// Implementation of IPropertyHelper
    /// </summary>
    public class PropertyHelper : IPropertyHelper
    {
        #region Properties

        private readonly IPropertyRepository _propertyRepository;
            
        #endregion
        
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyRepository"></param>
        public PropertyHelper(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
            // _featureRepository = featureRepository ?? throw new ArgumentNullException(nameof(featureRepository));
        }

        #endregion

        #region Public methods

        /// <summary>
        /// GetAllService
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IEnumerable<PropertyResponse> GetAllProperties()
        {    
            var response = _propertyRepository.GetProperties();
            //ServiceResponse response = new ServiceResponse();
            //response = res;
            return response;
        }

        public PropertyResponse GetOneProperty(string address)
        {
            var response = _propertyRepository.GetProperty(address);
            return response;
        }

        public string AddNewProperty(PropertyRequest property)
        {
            var response = _propertyRepository.AddProperty(property);
            return response;
        }

        public string UpdateOldProperty(PropertyRequest property)
        {
            var response = _propertyRepository.UpdateProperty(property);
            return response;
        }

        public string DeleteOldProperty(string address)
        {
            var response = _propertyRepository.DeleteProperty(address);
            return response;
        }


        #endregion
    }
}