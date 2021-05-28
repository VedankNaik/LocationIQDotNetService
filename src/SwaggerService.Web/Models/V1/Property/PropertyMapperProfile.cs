using AutoMapper;
using SwaggerService.Core.Models.Service;
using SwaggerService.Core.Models.V1.Property;

namespace SwaggerService.Web.Models.V1.Property
{
    /// <summary>
    /// Mapper Profile for Property
    /// </summary>
    public class PropertyMapperProfile : Profile
    {
        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public PropertyMapperProfile()
        {
            // Automapper profiles
            // this.CreateMap<ServiceRequest, ServiceRequestDto>(); 
            // this.CreateMap<ServiceResponse, ServiceResponseDto>();    
            this.CreateMap<PropertyRequestDto, PropertyRequest>(); 
            this.CreateMap<PropertyResponse, PropertyResponseDto>();      
        }

        #endregion
    }
}