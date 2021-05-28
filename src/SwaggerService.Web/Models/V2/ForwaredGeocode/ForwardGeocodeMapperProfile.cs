using AutoMapper;
using SwaggerService.Core.Models.V2.ForwardGeocode;

namespace SwaggerService.Web.Models.V2.ForwardGeocode
{
    /// <summary>
    /// Mapper Profile for ForwardGeocode
    /// </summary>
    public class ForwardGeocodeMapperProfile : Profile
    {
        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ForwardGeocodeMapperProfile()
        {
            // Automapper profiles   
            this.CreateMap<ForwardGeocodeRequestDto, ForwardGeocodeRequest>(); 
            this.CreateMap<ForwardGeocodeResponse, ForwardGeocodeResponseDto>();      
        }

        #endregion
    }
}