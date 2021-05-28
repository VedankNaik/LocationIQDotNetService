using System.Collections.Generic;
using System.Threading.Tasks;
using SwaggerService.Core.Models.Features;
using SwaggerService.Core.Models.V1.Property;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerService.Core.Interfaces.Infrastructure.Repositories.V1
{
    /// <summary>
    /// IPropertyRepository interface
    /// </summary>
    public interface IPropertyRepository
    {
        #region Methods

        /// <summary>
        /// GetProperties
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        IEnumerable<PropertyResponse> GetProperties();

        /// <summary>
        /// GetProperty
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        PropertyResponse GetProperty(string address);

        /// <summary>
        /// AddProperty
        /// </summary>
        /// <param name="address"></param>
        /// <param name="ownerName"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        string AddProperty(PropertyRequest property);

        
        /// <summary>
        /// UpdateProperty
        /// </summary>
        /// <param name="address"></param>
        /// <param name="ownerName"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        string UpdateProperty(PropertyRequest property);

        /// <summary>
        /// DeleteProperty
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        string DeleteProperty(string address);

        #endregion

    }
}