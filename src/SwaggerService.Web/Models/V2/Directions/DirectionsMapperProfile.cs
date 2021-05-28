using AutoMapper;
using SwaggerService.Core.Models.V2.Directions;

namespace SwaggerService.Web.Models.V2.Directions
{
    /// <summary>
    /// Mapper Profile for Directions
    /// </summary>
    public class DirectionsMapperProfile : Profile
    {
        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public DirectionsMapperProfile()
        {
            // Automapper profiles   
            this.CreateMap<DirectionsRequestDto, DirectionsRequest>(); 
            this.CreateMap<DirectionsResponse, DirectionsResponseDto>();      
        }

        #endregion
    }
}