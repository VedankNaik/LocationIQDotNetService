using AutoMapper;
using SwaggerService.Core.Models.Service;

namespace SwaggerService.Web.Models.V1.Service
{
    /// <summary>
    /// Mapper Profile for Features
    /// </summary>
    public class ServiceMapperProfile : Profile
    {
        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceMapperProfile()
        {
            // Automapper profiles
            // this.CreateMap<ServiceRequest, ServiceRequestDto>(); 
            // this.CreateMap<ServiceResponse, ServiceResponseDto>();    
            this.CreateMap<ServiceRequestDto, ServiceRequest>(); 
            this.CreateMap<ServiceResponse, ServiceResponseDto>();      
        }

        #endregion
    }
}