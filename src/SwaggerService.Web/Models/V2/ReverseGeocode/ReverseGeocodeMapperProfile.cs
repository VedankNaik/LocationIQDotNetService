using AutoMapper;
using SwaggerService.Core.Models.V2.ReverseGeocode;

namespace SwaggerService.Web.Models.V2.ReverseGeocode
{
    /// <summary>
    /// Mapper Profile for ReverseGeocode
    /// </summary>
    public class ReverseGeocodeMapperProfile : Profile
    {
        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ReverseGeocodeMapperProfile()
        {
            // Automapper profiles   
            this.CreateMap<ReverseGeocodeRequestDto, ReverseGeocodeRequest>(); 
            this.CreateMap<ReverseGeocodeResponseObject, ReverseGeocodeResponseDto>();      
        }

        #endregion
    }
}