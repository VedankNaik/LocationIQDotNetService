using AutoMapper;
using SwaggerService.Core.Models.V2.POI;

namespace SwaggerService.Web.Models.V2.POI
{
    /// <summary>
    /// Mapper Profile for POI
    /// </summary>
    public class POIMapperProfile : Profile
    {
        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public POIMapperProfile()
        {
            // Automapper profiles   
            this.CreateMap<POIRequestDto, POIRequest>();    
            this.CreateMap<POIResponse, POIResponseDto>();    
        }

        #endregion
    }
}