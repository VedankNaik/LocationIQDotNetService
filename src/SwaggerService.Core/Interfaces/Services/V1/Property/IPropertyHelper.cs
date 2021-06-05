using System.Collections.Generic;
using System.Threading.Tasks;
using SwaggerService.Core.Models.V1.Property;

namespace SwaggerService.Core.Interfaces.Services.V1.Property
{
    /// <summary>
    /// IPropertyHelper
    /// </summary>
    public interface IPropertyHelper 
    {
        #region Methods

        /// <summary>
        /// GetAllProperties
        /// </summary>
        /// 
        /// <returns></returns>
        IEnumerable<PropertyResponse> GetAllProperties();     

        /// <summary>
        /// GetProperty
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        PropertyResponse GetOneProperty(string address);

        /// <summary>
        /// AddProperty
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        string AddNewProperty(PropertyRequest property);

        
        /// <summary>
        /// UpdateProperty
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        string UpdateOldProperty(PropertyRequest property);

        /// <summary>
        /// DeleteProperty
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        string DeleteOldProperty(string address);   

        #endregion
                                   
    }
}